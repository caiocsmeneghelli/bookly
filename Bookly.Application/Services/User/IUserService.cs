using Bookly.Application.Model.InputModels;
using Bookly.Core.Entities;

namespace Bookly.Application.Service
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserInputModel inputModel);
    }
}