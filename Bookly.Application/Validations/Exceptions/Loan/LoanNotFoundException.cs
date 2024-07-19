namespace Bookly.Application.Validations.Exceptions;

public class LoanNotFoundException : NotFoundException
{
    public LoanNotFoundException(int id) : base($"Empréstimo de id {id} não encontrado.") { }
}
