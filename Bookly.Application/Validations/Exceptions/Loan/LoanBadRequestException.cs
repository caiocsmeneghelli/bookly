using FluentValidation.Results;

namespace Bookly.Application.Validations.Exceptions;

public class LoanBadRequestException: BadRequestException
{
    public LoanBadRequestException(List<ValidationFailure> validationFailures) : 
        base("Loan validation failed.", validationFailures
            .Select(reg => reg.ErrorMessage).ToList())
    {
        
    }
}
