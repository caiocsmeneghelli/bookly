
using FluentValidation.Results;

namespace Bookly.Application.Validations.Exceptions;

public sealed class UserBadRequestException : BadRequestException
{
    public UserBadRequestException(List<ValidationFailure> validationFailures) :
        base("User validation failed.", validationFailures
            .Select(reg => reg.ErrorMessage).ToList())
    { }
}
