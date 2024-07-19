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
        private Book? _book;
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
                }).WithMessage(reg => $"Usuário de Id {reg.IdUser} não encontrado.");
            });

            When(reg => reg.IdBook != 0, () =>
            {
                RuleFor(reg => reg).MustAsync(async (s, token) =>
                {
                    _book = await _bookRepository.FindByIdAsync(s.IdBook);
                    return _book != null;
                }).WithMessage(reg => $"Livro de Id {reg.IdBook} não encontrado.");

            });

            When(reg => _book != null, () =>
            {
                RuleFor(reg => reg).Must((s, token) =>
               {
                   if (_book == null) { return false; }

                   return _book.Available;
               }).WithMessage(reg => $"Livro de Id {reg.IdBook} não está disponível.");
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

