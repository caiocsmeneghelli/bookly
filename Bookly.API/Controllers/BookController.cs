using Bookly.Application.Model.InputModels;
using Bookly.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(string param)
        {
            // todo: Criar se ativos ou nao
            var books = await _bookService.GetBooksAsync(param);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var vwModel = await _bookService.GetBookyIdAsync(id);
            return Ok(vwModel);
        }


        [HttpPost("")]
        public async Task<IActionResult> Post(BookInputModel inputModel)
        {
            int bookId = await _bookService.AddBookAsync(inputModel);
            if (bookId == 0) { return BadRequest("Falha ao adicionar livro."); }

            return CreatedAtAction(nameof(GetBook), new { id = bookId }, inputModel);
        }

        [HttpDelete("{idBook}")]
        public async Task<IActionResult> Delete(int idBook)
        {
            try
            {
                await _bookService.RemoveBookAsync(idBook);
                return Ok("Livro deletado.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}