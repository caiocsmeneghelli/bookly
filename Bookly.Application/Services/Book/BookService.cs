using Bookly.Application.Model.InputModels;
using Bookly.Application.Model.ViewModels;
using Bookly.Core.Entities;
using Bookly.Core.Repositories;

namespace Bookly.Application.Services{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> AddBookAsync(BookInputModel inputModel)
        {
            // To-Do: Criar validações
            Book book = new Book(inputModel.Author, inputModel.ISBN,
                inputModel.PublishYear, inputModel.Title);
            await _bookRepository.CreateAsync(book);
            return book.Id;
        }

        public async Task<List<BookViewModel>> GetBooksAsync(string param)
        {
            var books = await _bookRepository.GetAllAsync(param);
            return books.Select(reg => new BookViewModel(reg)).ToList(); 
        }

        public async Task<BookViewModel> GetBookyIdAsync(int id)
        {
            Book? book = await _bookRepository.FindByIdAsync(id);
            if(book == null)
                throw new Exception("Livro não encontrado.");
            
            return new BookViewModel(book);
        }

        public async Task RemoveBookAsync(int idBook)
        {
            Book? book = await _bookRepository.FindByIdAsync(idBook);
            if(book == null)
                throw new Exception("Livro não encontrado.");
            
            await _bookRepository.RemoveAsync(idBook);
        }
    }
}