using Bookly.Core.Entities;

namespace Bookly.Core.Repositories{
    public interface IUserRepository{
        Task<User?> FindByIdAsync(int id);
        Task CreateAsync(User user);
    }
}