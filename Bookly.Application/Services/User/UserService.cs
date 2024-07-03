using Bookly.Application.Model.InputModels;
using Bookly.Application.Service;
using Bookly.Core.Entities;
using Bookly.Core.Repositories;

namespace Bookly.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUserAsync(UserInputModel inputModel)
        {
            // Add validation
            User user = new User(inputModel.Name, inputModel.Email);
            await _userRepository.CreateAsync(user);
            return user.Id;
        }
    }
}