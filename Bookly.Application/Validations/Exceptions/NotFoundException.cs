namespace Bookly.Application.Validations.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, int id) : base(message)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}