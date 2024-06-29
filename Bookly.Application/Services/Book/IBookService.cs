using Bookly.Application.Model.InputModels;
using Bookly.Application.Model.ViewModels;

namespace Bookly.Application.Service{
    public interface IBookService{
        Task AddBookAsync(BookInputModel inputModel);
        Task RemoveBookAsync(int idBook);
        Task<BookViewModel> GetBookyIdAsync(int id);
        Task<List<BookViewModel>> GetBooksAsync(string param);
    }
}