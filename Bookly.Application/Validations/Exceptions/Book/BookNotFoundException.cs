namespace Bookly.Application.Validations.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"Livro de id {id} não encontrado."){}
    }
}