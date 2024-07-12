namespace Bookly.Application.Model
{
    public class LoanViewModel{
        public LoanViewModel(string bookName, string userName, DateTime loanDate,
             DateTime returnDate)
        {
            BookName = bookName;
            UserName = userName;
            LoanDate = loanDate;
            ReturnDate = returnDate;
            
            CountDelayedDays();
        }

        public string BookName { get; private set; }
        public string UserName { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public int DelayedDays { get; private set; }

        public void CountDelayedDays(){
            if(ReturnDate < DateTime.Now){
                DelayedDays = (DateTime.Now - ReturnDate).Days;
            }
        }
    }
}