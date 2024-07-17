using System.ComponentModel.DataAnnotations;
using Bookly.Application.Model.InputModels;
using Bookly.Application.Model.ViewModels;
using Bookly.Application.Validations.Exceptions;
using Bookly.Application.Validations.Validators;
using Bookly.Core.Entities;
using Bookly.Core.Repositories;
using FluentValidation;

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
            var validator = new UserInputModelValidator();
            var result = validator.Validate(inputModel);
            if(result.IsValid == false){
                throw new UserBadRequestException(result.Errors);
            }

            User user = new User(inputModel.Name, inputModel.Email);
            await _userRepository.CreateAsync(user);
            return user.Id;
        }

        public async Task<UserViewModel?> GetUserAsync(int idUser)
        {
            User? user = await _userRepository.FindByIdAsync(idUser);
            if(user == null){
                throw new UserNotFoundException(idUser);
            }

            return new UserViewModel(user.Name, user.Email);
        }
    }
}