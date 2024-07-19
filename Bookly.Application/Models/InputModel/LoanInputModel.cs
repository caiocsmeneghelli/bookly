namespace Bookly.Application.Model
{
    public class LoanInputModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime? DueDate { get; set; }
    }
}