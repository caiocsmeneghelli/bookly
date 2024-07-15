namespace Bookly.Application.Validations.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {}
    }
}