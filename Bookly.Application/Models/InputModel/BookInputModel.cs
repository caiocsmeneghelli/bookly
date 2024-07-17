using System.ComponentModel.DataAnnotations;

namespace Bookly.Application.Model.InputModels
{
    public class BookInputModel
    {
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public DateTime? PublishYear { get; set; }
    }
}