using back_softek.Application.Dtos;

namespace back_softek.Application.IServices
{
    public interface ILibroService
    {
        Task<LibroDto> CreateLibro(CreateLibroDto dto);
        Task<LibroDto?> GetLibroById(int id);
        Task<IEnumerable<LibroDto>> GetAllLibros();
        Task<bool> UpdateLibro(int id, CreateLibroDto dto);
        Task<bool> DeleteLibro(int id);
       
    }
}
