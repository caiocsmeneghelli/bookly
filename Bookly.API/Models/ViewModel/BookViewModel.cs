using Bookly.Core.Entities;

namespace Bookly.API.Models.ViewModels
{
    public class BookViewModel{
        public BookViewModel(string author, string iSBN, int publishYear)
        {
            Author = author;
            ISBN = iSBN;
            PublishYear = publishYear;
        }

        public BookViewModel(Book book)
        {
            Author = book.Author;
            ISBN = book.ISBN;
            PublishYear = book.PublishYear;
        }

        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublishYear { get; private set; }
    }
}