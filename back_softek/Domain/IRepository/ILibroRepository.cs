
using back_softek.Domain.Entities;

namespace back_softek.Domain.IRepository
{
    public interface ILibroRepository
    {
        Task<Libro> CreateLibro(Libro libro);
        Task<Libro?> GetLibroById(int id);
        Task<IEnumerable<Libro>> GetAllLibros();
        Task<bool> UpdateLibro(Libro libro);
        Task<bool> DeleteLibro(Libro libro);
        Task<int> GetCantLibros(int id);
    }
}
