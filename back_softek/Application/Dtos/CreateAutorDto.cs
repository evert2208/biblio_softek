using System.ComponentModel.DataAnnotations;

namespace back_softek.Application.Dtos
{
    public class CreateAutorDto
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        public string nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime fechaNac { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        public string ciudadProcedencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string correo { get; set; } = string.Empty;
    }
}
