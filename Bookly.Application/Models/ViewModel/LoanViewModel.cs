using Bookly.Core.Entities;

namespace Bookly.Application.Model
{
    public class LoanViewModel
    {
        public LoanViewModel(Loan loan)
        {
            IdLoan = loan.Id;
            BookName = loan.Book.Title;
            IdBook = loan.BookId;
            UserName = loan.User.Name;
            IdUser = loan.UserId;
            LoanDate = loan.LoanDate;
            DueDate = loan.DueDate;
            ReturnDate = loan.ReturnDate;

            CountDelayedDays();
        }

        public int IdLoan { get; private set; }
        public string BookName { get; private set; }
        public int IdBook { get; private set; }
        public string UserName { get; private set; }
        public int IdUser { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public int DelayedDays { get; private set; }

        public void CountDelayedDays()
        {
            if (ReturnDate is not null)
            {
                if (ReturnDate.Value > DueDate)
                {
                    DelayedDays = (ReturnDate.Value - DueDate).Days;
                }
            }
            else
            {
                if (DateTime.Now > DueDate)
                {
                    DelayedDays = (DateTime.Now - DueDate).Days;
                }
            }
        }
    }
}