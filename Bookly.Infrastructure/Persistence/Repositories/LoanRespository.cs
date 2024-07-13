using Bookly.Core.Entities;
using Bookly.Core.Repositories;
using Bookly.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly DataContext _context;

        public LoanRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            return loan.Id;
        }

        public async Task<List<Loan>> GetAllAsync(bool active)
        {
            var query = _context.Loans.AsQueryable();
            if(active){
                query = query.Where(loan => loan.ReturnDate.HasValue);
            }

            query = query.Include(reg => reg.User)
                .Include(reg => reg.Book);

            return await query.ToListAsync();
        }

        public async Task<Loan?> GetLoanAsync(int id)
        {
            return await _context.Loans
                .Include(reg => reg.Book)
                .Include(reg => reg.User)
                .SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Loan loan)
        {
            await _context.SaveChangesAsync();
        }
    }
}