using Bookly.Core.Entities;
using Bookly.Core.Repositories;
using Bookly.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Infrastructure.Persistence.Repositories {
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;

        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Book book)
        {
            await _dataContext.Books.AddAsync(book);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Book?> FindByIdAsync(int id)
        {
            return await _dataContext.Books
                .SingleOrDefaultAsync(reg => reg.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync(string param)
        {
            var books = _dataContext.Books.AsQueryable();
            if(param != ""){
                books = books.Where(reg => param.Contains(reg.Author) || 
                    param.Contains(reg.Title));
            }
            return await books.AsNoTracking()
                .ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            Book? book = await _dataContext
                .Books.SingleOrDefaultAsync(reg => reg.Id == id);
            if(book is not null){
                _dataContext.Books.Remove(book);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Book book)
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}