using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using maple_web_api_async.Filters;
using maple_web_api_async.ModelBinders;
using maple_web_api_async.Models;
using maple_web_api_async.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace maple_web_api_async.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    [BooksResultFilter]
    public class BookCollectionsController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookCollectionsController(IBookRepository bookRepository, IMapper mapper)
        {
            _repository = bookRepository ?? throw new System.ArgumentNullException(nameof(bookRepository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }
        [HttpPost]
        public async Task<IActionResult> AddBooksCollection(IEnumerable<BookForCreation> books)
        {
            var booksForCreations = _mapper.Map<IEnumerable<Entities.Book>>(books);

            foreach (var book in booksForCreations)
            {
                _repository.AddBook(book);
            }


            await _repository.SaveChangesAsync();

            var booksToReturn = await _repository.GetBooksAsync(booksForCreations.Select(b => b.Id));

            var Ids = String.Join(',', booksToReturn.Select(b => b.Id));

            return CreatedAtAction("GetBooksCollection", new { Ids }, booksToReturn);
        }

        [HttpGet("({ids})", Name = "GetBooksCollection")]
        public async Task<IActionResult> GetBooksCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var bookEntities = await _repository.GetBooksAsync(ids);


            return Ok(bookEntities);
        }
    }
}