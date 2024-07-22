using Bookly.Application.Model.InputModels;
using FluentValidation;
using System.Text.RegularExpressions;

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

            When(reg => !string.IsNullOrWhiteSpace(reg.Email), () =>
            {
                RuleFor(reg => reg.Email)
                    .Must(ValidateEmail)
                    .WithMessage("E-mail informado não válido.");
            });
        }

        private bool ValidateEmail(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

    }
}