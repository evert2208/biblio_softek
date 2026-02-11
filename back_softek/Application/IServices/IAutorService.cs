using back_softek.Application.Dtos;

namespace back_softek.Application.IServices
{
    public interface IAutorService
    {
        Task<AutorDto> CreateAutor(CreateAutorDto dto);
        Task<AutorDto?> GetAutorbyId(int id);
        Task<IEnumerable<AutorDto>> GetAllAutores();
        Task UpdateAutor(int id, CreateAutorDto dto);
       
    }
}
