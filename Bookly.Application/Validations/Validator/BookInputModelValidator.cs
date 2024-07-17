using Bookly.Application.Model.InputModels;
using FluentValidation;

namespace Bookly.Application.Validations.Validators
{
    public class BookInputModelValidator : AbstractValidator<BookInputModel>
    {
        public BookInputModelValidator()
        {
            RuleFor(reg => reg)
                .NotNull()
                .WithMessage("Não é possível passar o objeto vazio.");

            RuleFor(reg => reg.Title)
                .NotEmpty()
                .WithMessage("Titulo do livro não pode ser vazio.");

            When(reg => reg.Title is not null, () =>
            {
                RuleFor(reg => reg.Title)
                                .MinimumLength(3)
                                .WithMessage("Titulo do livro deve ter no minimo 3 caracteres.");

            });

            RuleFor(reg => reg.Author)
                .NotEmpty()
                .WithMessage("O nome do Autor do livro não pode ser vazio.");

            When(reg => reg.Author is not null, () =>
            {
                RuleFor(reg => reg.Author)
                                .MinimumLength(3)
                                .WithMessage("O nome do Autor do livro deve ter no minimo 3 caracteres.");

            });

            RuleFor(reg => reg.ISBN)
                .NotEmpty()
                .WithMessage("ISBN não pode ser vazio.");

            RuleFor(reg => reg.PublishYear)
                .NotNull()
                .Must(ValidadePublishYear)
                .WithMessage("Valor de data de publicação inválido.");
        }

        private bool ValidadePublishYear(DateTime? publishYear){
            
            if(publishYear.Value >= DateTime.Now || DateTime.MinValue.Equals(publishYear)){
                return false;
            }
            return true;
        }
    }
}