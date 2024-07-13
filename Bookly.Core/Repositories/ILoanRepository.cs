using Bookly.Core.Entities;

namespace Bookly.Core.Repositories{
    public interface ILoanRepository{
        Task<Loan?> GetLoanAsync(int id);
        Task<int> CreateAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task<List<Loan>> GetAllAsync(bool active);
    }
}