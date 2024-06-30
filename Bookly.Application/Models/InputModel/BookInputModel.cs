using System.ComponentModel.DataAnnotations;

namespace Bookly.Application.Model.InputModels
{
    public class BookInputModel
    {
        [Required(ErrorMessage = "Campo Autor obrigatório.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Campo Título obrigatório.")]
        public string Title { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "ISBN precisa ter 13 digitos")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Campo Ano de Publicação obrigatório.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public int PublishYear { get; set; }
    }
}