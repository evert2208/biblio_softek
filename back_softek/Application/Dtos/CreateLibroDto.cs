using System.ComponentModel.DataAnnotations;

namespace back_softek.Application.Dtos
{
    public class CreateLibroDto
    {
        public int id { get; set; } = 0;

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(250)]
        public string titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año es obligatorio")]
        [Range(1000, 2030)]
        public int año { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        [StringLength(100)]
        public string genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        [Range(1, 10000)]
        public int numeroPaginas { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public int autorId { get; set; }
    }
}
