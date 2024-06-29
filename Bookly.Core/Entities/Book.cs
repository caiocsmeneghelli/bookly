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

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublishYear { get; private set; }
    }
}