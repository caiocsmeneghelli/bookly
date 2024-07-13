using Bookly.Core.Entities;

namespace Bookly.Application.Model.ViewModels{
    public class BookViewModel{
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishYear { get; set; }
        public bool Available { get; set; }

        public BookViewModel(Book book)
        {
            Title = book.Title;
            Author = book.Author;
            ISBN = book.ISBN;
            PublishYear = book.PublishYear;
            Available = book.Available;
        }
    }
}