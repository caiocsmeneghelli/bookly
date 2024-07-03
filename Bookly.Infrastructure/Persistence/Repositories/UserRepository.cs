using Bookly.Core.Entities;
using Bookly.Core.Repositories;
using Bookly.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
    private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> FindByIdAsync(int id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}