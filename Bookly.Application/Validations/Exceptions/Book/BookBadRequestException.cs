
using FluentValidation.Results;

namespace Bookly.Application.Validations.Exceptions;

public sealed class BookBadRequestException : BadRequestException
{
    public BookBadRequestException(List<ValidationFailure> validationFailures) : 
        base("Book validation failed.", validationFailures
            .Select(reg => reg.ErrorMessage).ToList())
    {
    }
}
