using System.ComponentModel.DataAnnotations;

namespace back_softek.Application.Dtos
{
    public record LibroDto
   (
       int id, string titulo, int año, string genero, int numeroPaginas, int autorId
   );
}
