
namespace Bookly.Application.Validations.Exceptions;

public sealed class BookBadRequestException : BadRequestException
{
    public BookBadRequestException(List<string> errors) : base("Book validation failed.", errors)
    {
    }
}
