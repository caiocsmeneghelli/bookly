namespace Bookly.Core.Entities
{
    public class Loan
    {
        public Loan(int bookId, int userId,
        DateTime dueDate)
        {
            BookId = bookId;
            UserId = userId;
            LoanDate = DateTime.Now;
            DueDate = dueDate;
        }

        public int Id { get; private set; }
        public Book Book { get; private set; }
        public int BookId { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public void ReturnLoan()
        {
            ReturnDate = DateTime.Now;
        }
    }
}