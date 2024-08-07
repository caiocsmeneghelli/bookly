using Bookly.Application.Model.InputModels;
using Bookly.Application.Model.ViewModels;
using Bookly.Application.Validations.Exceptions;
using Bookly.Application.Validations.Validators;
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
            var validator = new BookInputModelValidator();
            var result = validator.Validate(inputModel);
            if(result.IsValid == false){
                throw new BookBadRequestException(result.Errors);
            }

            Book book = new Book(inputModel.Author, inputModel.ISBN,
                inputModel.PublishYear.Value, inputModel.Title);
            await _bookRepository.CreateAsync(book);
            return book.Id;
        }

        public async Task<List<BookViewModel>> GetBooksAsync(string? param = null)
        {
            var books = await _bookRepository.GetAllAsync(param);
            return books.Select(reg => new BookViewModel(reg)).ToList(); 
        }

        public async Task<BookViewModel?> GetBookyIdAsync(int id)
        {
            Book? book = await _bookRepository.FindByIdAsync(id);
            if (book == null)
                return null;
            
            return new BookViewModel(book);
        }

        public async Task RemoveBookAsync(int idBook)
        {
            Book? book = await _bookRepository.FindByIdAsync(idBook);
            if(book == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            await _bookRepository.RemoveAsync(idBook);
        }
    }
}