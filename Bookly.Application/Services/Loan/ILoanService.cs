using Bookly.Application.Model;
using Bookly.Core.Entities;

namespace Bookly.Application.Service
{
    public interface ILoanService {
        Task<int> CreateAsync(LoanInputModel inputModel);
        Task<LoanViewModel?> ReturnLoan(int idLoan);
        Task<LoanViewModel?> GetByIdAsync(int idLoan);
    }
}