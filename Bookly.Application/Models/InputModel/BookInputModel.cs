namespace Bookly.Application.Model.InputModels{
    public record BookInputModel{
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishYear { get; set; }
    }
}