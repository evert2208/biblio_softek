using back_softek.Domain.Entities;

namespace back_softek.Domain.IRepository
{
    public interface IAutorRepository
    {
        Task<Autor> CreateAutor(Autor autor);
        Task<Autor?> GetAutorbyId(int id);
        Task<IEnumerable<Autor>> GetAllAutores();
        Task UpdateAutor(Autor autor);
        
    }
}
