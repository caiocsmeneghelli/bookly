using Bookly.Core.Entities;

namespace Bookly.Core.Repositories{
    public interface ILoanRepository{
        Task<Loan> GetLoanAsync(int id);
        Task UpdateAsync(Loan loan);
    }
}