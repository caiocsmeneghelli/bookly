namespace Bookly.Core.Entities
{
    public class Book
    {
        public Book(string author, string iSBN, DateTime publishYear, string title)
        {
            Author = author;
            ISBN = iSBN;
            PublishYear = publishYear;
            Title = title;
            Available = true;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public DateTime PublishYear { get; private set; }
        public bool Available { get; private set; }

        public void Loan(){
            Available = false;
        }

        public void ReturnLoan(){
            Available = true;
        }
    }
}