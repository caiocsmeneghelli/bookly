using Bookly.Application.Model.InputModels;
using FluentValidation;

namespace Bookly.Application.Validations.Validators
{
    public class UserInputModelValidator : AbstractValidator<UserInputModel>
    {
        public UserInputModelValidator()
        {
            RuleFor(reg => reg.Name)
                .NotEmpty()
                .WithMessage("Campo nome do usuário não pode ser vazio.");
            
            RuleFor(reg => reg.Email)
                .NotEmpty()
                .WithMessage("Campo email do usuário não pode ser vazio.");
        }
    }
}