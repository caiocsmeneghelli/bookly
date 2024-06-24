using Bookly.API.Model.InputModels;
using Bookly.API.Models.ViewModels;
using Bookly.Core.Entities;
using Bookly.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Controllers
{
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id){
            var book = await _bookRepository.FindByIdAsync(id);
            if(book is null){
                return BadRequest("Book not found.");
            }
            BookViewModel vwModel = new BookViewModel(book);
            return Ok(vwModel);
        }


        [HttpPost("")]
        public async Task<IActionResult> Post(BookInputModel inputModel)
        {
            // Adicionar Validacao
            Book book = new Book(inputModel.Author, inputModel.ISBN, inputModel.PublishYear);
            await _bookRepository.CreateAsync(book);

            return CreatedAtAction(nameof(GetBook), new {id = book.Id}, inputModel);
        }
    }
}