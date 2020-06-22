using System;
using System.Threading.Tasks;
using maple_web_api_async.Filters;
using maple_web_api_async.Services;
using Microsoft.AspNetCore.Mvc;

namespace maple_web_api_async.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            if (repository is null)
            {
                throw new System.ArgumentNullException(nameof(repository));
            }

            _repository = repository;
        }
        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _repository.GetBooksAsync());
        }

        [HttpGet]
        [Route("{id}")]
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
    }
}