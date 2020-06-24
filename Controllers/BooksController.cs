using System;
using System.Threading.Tasks;
using AutoMapper;
using maple_web_api_async.Filters;
using maple_web_api_async.Models;
using maple_web_api_async.Services;
using Microsoft.AspNetCore.Mvc;

namespace maple_web_api_async.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository repository, IMapper mapper)
        {
            if (repository is null)
            {
                throw new System.ArgumentNullException(nameof(repository));
            }
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository;
        }
        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _repository.GetBooksAsync());
        }

        [HttpGet]
        [Route("{id}", Name = "GetBook")]
        [BookResultFilter]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _repository.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [BookResultFilter]
        public async Task<IActionResult> CreateBook([FromBody] BookForCreation book)
        {
            var entity = _mapper.Map<Entities.Book>(book);
            _repository.AddBook(entity);
            await _repository.SaveChangesAsync();

            await _repository.GetBookAsync(entity.Id);

            return CreatedAtAction("GetBook", new { id = entity.Id }, entity);
        }
    }
}