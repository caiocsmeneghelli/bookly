namespace Bookly.Core.Entities{
    public class Loan{
        public Loan(Book book, int bookId, User user, int userId, 
        DateTime loanDate, DateTime dueDate)
        {
            Book = book;
            BookId = bookId;
            User = user;
            UserId = userId;
            LoanDate = loanDate;
            DueDate = dueDate;
        }

        public int Id { get; private set; }
        public Book Book { get; private set; }
        public int BookId { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
    }
}