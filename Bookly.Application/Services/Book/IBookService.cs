using Bookly.Application.Model.InputModels;
using Bookly.Application.Model.ViewModels;

namespace Bookly.Application.Services
{
    public interface IBookService
    {
        Task<int> AddBookAsync(BookInputModel inputModel);
        Task RemoveBookAsync(int idBook);
        Task<BookViewModel?> GetBookyIdAsync(int id);
        Task<List<BookViewModel>> GetBooksAsync(string? param = null);
    }
}