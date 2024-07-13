using Bookly.Application.Model.InputModels;
using Bookly.Application.Model.ViewModels;
using Bookly.Core.Entities;

namespace Bookly.Application.Services
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserInputModel inputModel);
        Task<UserViewModel> GetUserAsync(int idUser);
    }
}