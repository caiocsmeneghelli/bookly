namespace Bookly.Application.Model.InputModels{
    public class BookInputModel{
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishYear { get; set; }
    }
}