using Bookly.Core.Entities;

namespace Bookly.Application.Model.ViewModels{
    public class BookViewModel{
        public int IdBook { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public DateTime PublishYear { get; private set; }
        public bool Available { get; private set; }

        public BookViewModel(Book book)
        {
            IdBook = book.Id;
            Title = book.Title;
            Author = book.Author;
            ISBN = book.ISBN;
            PublishYear = book.PublishYear;
            Available = book.Available;
        }
    }
}