namespace Bookly.Application.Validations.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        public BadRequestException(string message, List<string> errors) : base(message)
        {
            Errors = errors;
        }

        public List<string> Errors { get; private set; }
    }
}
