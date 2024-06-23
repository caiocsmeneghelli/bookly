namespace Bookly.Core.Entities
{
    public class Book
    {
        public Book(string author, string iSBN, int publishYear)
        {
            Author = author;
            ISBN = iSBN;
            PublishYear = publishYear;
        }

        public int Id { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublishYear { get; private set; }
    }
}