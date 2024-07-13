namespace Bookly.Core.Entities
{
    public class Book
    {
        public Book(string author, string iSBN, int publishYear, string title)
        {
            Author = author;
            ISBN = iSBN;
            PublishYear = publishYear;
            Title = title;
        }

        public Book(int id, string title, string author, string iSBN,
            int publishYear, int quantity)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublishYear = publishYear;
            Available = true;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublishYear { get; private set; }
        public bool Available { get; private set; }

        public void Loan(){
            Available = false;
        }

        public void ReturnLoan(){
            Available = true;
        }
    }
}