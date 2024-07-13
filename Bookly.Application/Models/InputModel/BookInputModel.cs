using System.ComponentModel.DataAnnotations;

namespace Bookly.Application.Model.InputModels
{
    public class BookInputModel
    {
        [Required(ErrorMessage = "Campo Autor obrigat�rio.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Campo T�tulo obrigat�rio.")]
        public string Title { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "ISBN precisa ter 13 digitos")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Campo Ano de Publica��o obrigat�rio.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishYear { get; set; }
    }
}