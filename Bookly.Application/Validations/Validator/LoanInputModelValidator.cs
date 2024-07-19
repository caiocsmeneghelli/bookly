using System.Data;
using Bookly.Application.Model;
using Bookly.Core.Entities;
using Bookly.Core.Repositories;
using FluentValidation;

namespace Bookly.Application.Validations.Validators
{
    public class LoanInputModelValidator : AbstractValidator<LoanInputModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public LoanInputModelValidator(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;

            RuleFor(reg => reg.IdUser)
                .NotEmpty()
                .WithMessage("Campo IdUser não pode ser vazio.");

            RuleFor(reg => reg.IdBook)
                .NotEmpty()
                .WithMessage("Campo IdBook não pode ser vazio.");

            RuleFor(reg => reg.DueDate)
                .Must(ValidateDueDate)
                .WithMessage("Data de entrega não pode ser vazio ou anterior a data de hoje.");

            When(reg => reg.IdUser != 0, () =>
            {
                RuleFor(reg => reg).MustAsync(async (s, token) =>
                {
                    var user = await _userRepository.FindByIdAsync(s.IdUser);
                    return user != null;
                }).WithMessage( reg => $"Usuário de Id {reg.IdUser} não encontrado.");
            });
        }

        private bool ValidateDueDate(DateTime? dueDate)
        {
            if (dueDate == null)
            {
                return false;
            }

            if (dueDate < DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }

}

