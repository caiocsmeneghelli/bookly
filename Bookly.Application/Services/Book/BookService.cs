using Bookly.Application.Model.InputModels;
using Bookly.Application.Model.ViewModels;

namespace Bookly.Application.Service{
    public class BookService : IBookService
    {
        public Task AddBookAsync(BookInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookViewModel>> GetBooksAsync(string param)
        {
            throw new NotImplementedException();
        }

        public Task<BookViewModel> GetBookyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBookAsync(int idBook)
        {
            throw new NotImplementedException();
        }
    }
}