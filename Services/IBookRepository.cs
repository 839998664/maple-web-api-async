using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using maple_web_api_async.Entities;

namespace maple_web_api_async.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(Guid id);

        void AddBook(Entities.Book book);

        Task<bool> SaveChangesAsync();
    }
}