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
            Quantity = quantity;
            QuantityAvailable = Quantity;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublishYear { get; private set; }

        public int Quantity { get; private set; }
        public int QuantityAvailable { get; private set; }

        public void Loan(){
            if(QuantityAvailable > 0){
                QuantityAvailable--;
            }
        }

        public void ReturnLoan(){
            if(QuantityAvailable < Quantity){
                QuantityAvailable++;
            }
        }
    }
}