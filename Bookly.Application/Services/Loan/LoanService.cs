using Bookly.Application.Model;
using Bookly.Application.Service;
using Bookly.Core.Entities;
using Bookly.Core.Repositories;

namespace Bookly.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public Task<int> CreateAsync(LoanInputModel inputModel)
        {

            throw new NotImplementedException();
        }

        public async Task<LoanViewModel?> GetByIdAsync(int idLoan)
        {
            Loan loan = await _loanRepository.GetLoanAsync(idLoan);
            if(loan is null){
                return null;
            }

            return new LoanViewModel(loan.Book.Title, loan.User.Name, 
                loan.LoanDate, loan.DueDate, loan.ReturnDate);
        }

        public async Task<LoanViewModel?> ReturnLoan(int idLoan)
        {
            Loan? loan = await _loanRepository.GetLoanAsync(idLoan);
            if(loan is null){
                return null;            
            }

            loan.ReturnLoan();

            return new LoanViewModel(loan.Book.Title, loan.User.Name, 
                loan.LoanDate, loan.DueDate, loan.ReturnDate);
        }
    }
}