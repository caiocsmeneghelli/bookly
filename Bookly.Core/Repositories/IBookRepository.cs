using Bookly.Core.Entities;

namespace Bookly.Core.Repositories{
    public interface IBookRepository{
        Task<IEnumerable<Book>> GetAllAsync(string param);
        Task<Book?> FindByIdAsync(int id);
        Task CreateAsync(Book book);
        Task RemoveAsync(int id);
    }
}