using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using maple_web_api_async.Contexts;
using maple_web_api_async.Entities;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api_async.Services
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }

        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }
    }
}