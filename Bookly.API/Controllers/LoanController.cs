using Bookly.Application.Model;
using Bookly.Application.Services;
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
            var loan = await _loanService.GetById(id);
            if (loan != null)
            {
                return Ok(loan);
            }
            return NotFound();
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var list = await _loanService.GetAll(true);
            return Ok(list);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(){
            var list = await _loanService.GetAll(false);
            return Ok(list);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(LoanInputModel model)
        {
            int idLoan = await _loanService.Create(model);
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