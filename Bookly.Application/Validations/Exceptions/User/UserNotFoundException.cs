namespace Bookly.Application.Validations.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int id) : base($"Usuário de id {id} não encontrado.")
        {
        }
    }
}