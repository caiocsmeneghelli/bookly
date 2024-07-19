using System.Data;
using Bookly.Core.Entities;
using FluentValidation;

namespace Bookly.Application.Validations.Validators;

public class LoanValidator : AbstractValidator<Loan>
{
    public LoanValidator()
    {
        RuleFor(reg => reg.ReturnDate)
            .Null()
            .WithMessage(reg => $"Emprestimo do livro {reg.Book.Title} já foi retornado.");
        
        RuleFor(reg => reg.Book.Available)
            .Equal(false)
            .WithMessage(reg => $"Não é possivel retornar o livro {reg.Book.Title}, pois o mesmo já esta disponível.");
    }

}
