using Bookly.Application.Model;
using Bookly.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = await _loanService.GetByIdAsync(id);
            if (loan != null)
            {
                return Ok(loan);
            }
            return NotFound();
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            // TODO
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(LoanInputModel model)
        {
            int idLoan = await _loanService.CreateAsync(model);
            if(idLoan == 0){
                return BadRequest("Falha ao criar emprestimo.");
            }

            return CreatedAtAction(nameof(GetById), new {id = idLoan}, model);
        }

        [HttpPut("{idLoan}")]
        public async Task<IActionResult> ReturnLoan(int idLoan)
        {
            LoanViewModel? vwModel = await _loanService.ReturnLoan(idLoan);
            if(vwModel is null){
                return NotFound("Empréstimo não encontrado.");
            }

            return Ok(vwModel);
        }
    }

}