using System.ComponentModel.DataAnnotations;

namespace back_softek.Application.Dtos
{
    public record AutorDto
    (
        int id, string nombre, string correo, DateTime? fechaNac, string ciudadProcedencia
    );
}
