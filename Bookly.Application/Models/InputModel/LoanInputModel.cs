namespace Bookly.Application.Model
{
    public class LoanInputModel
    {
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public DateTime? DueDate { get; private set; }
    }
}