using System.ComponentModel.DataAnnotations;

namespace WEB_API_2.DTOs
{
    public class CategoriaDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(255, ErrorMessage = "El nombre debe tener máximo 255 caracteres.")]
        public string? Nombre { get; set; }
    }
}