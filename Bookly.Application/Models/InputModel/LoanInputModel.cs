namespace Bookly.Application.Model
{
    public class LoanInputModel
    {
        public LoanInputModel(int idUser, int idBook, DateTime dueDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            DueDate = dueDate;
        }

        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public DateTime DueDate { get; private set; }
    }
}