using Bookly.Application.Model;
using Bookly.Core.Entities;

namespace Bookly.Application.Service
{
    public interface ILoanService {
        Task<int> Create(LoanInputModel inputModel);
        Task<LoanViewModel?> ReturnLoan(int idLoan);
        Task<LoanViewModel?> GetById(int idLoan);
        Task<List<LoanViewModel>> GetAll(bool active);
    }
}