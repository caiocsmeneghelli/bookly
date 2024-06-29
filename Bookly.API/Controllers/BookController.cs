using Bookly.Application.Model.InputModels;
using Bookly.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Controllers
{
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id){
            var vwModel = await _bookService.GetBookyIdAsync(id);
            return Ok(vwModel);
        }


        [HttpPost("")]
        public async Task<IActionResult> Post(BookInputModel inputModel)
        {
            int bookId = await _bookService.AddBookAsync(inputModel);
            if(bookId == 0) { return BadRequest("Falha ao adicionar livro."); }

            return CreatedAtAction(nameof(GetBook), new {id = bookId}, inputModel);
        }
    }
}