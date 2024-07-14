using Bookly.Application.Model.InputModels;

namespace Bookly.Application.Validation.Validator;

public class BookInputModelValidator
{
    private List<string> errors;
    public BookInputModelValidator(BookInputModel inputModel)
    {
        errors = new List<string>();
        if (string.IsNullOrEmpty(inputModel.Title))
        {
            errors.Add("Titulo do livro não pode ser vazio.");
        }

        if (inputModel.Title.Length < 3)
        {
            errors.Add("Titulo do livro deve ter no minimo 3 caracteres.");
        }

        if (string.IsNullOrEmpty(inputModel.Author))
        {
            errors.Add("Nome do autor do livro não pode ser vazio.");
        }

        if (inputModel.Author.Length < 3)
        {
            errors.Add("Nome do autor do livro deve ter no minimo 3 caracteres.");
        }

        if (string.IsNullOrEmpty(inputModel.ISBN))
        {
            errors.Add("ISBN não pode ser vazio.");
        }

        if (inputModel.PublishYear >= DateTime.Now || DateTime.MinValue.Equals(inputModel.PublishYear))
        {
            errors.Add("Valor de data de publicação inválido.");
        }
    }

    public bool IsValid()
    {
        return !errors.Any();
    }

    public List<string> ReturnErrors(){
        return errors;
    }
}
