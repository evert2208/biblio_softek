using back_softek.Domain.Entities;
using back_softek.Domain.IRepository;
using back_softek.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace back_softek.Infrastructure.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly AppDbContext _context;

        public LibroRepository(AppDbContext context) { 
            _context = context;
        }

        public async Task<Libro> CreateLibro(Libro libro)
        {
            _context.Libro.Add(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task<bool> DeleteLibro(Libro libro)
        {
            _context.Libro.Remove(libro);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Libro>> GetAllLibros()
        {
            return await _context.Libro.OrderBy(x => x.titulo).ToListAsync();
        }

        public async Task<int> GetCantLibros(int id)
        {
            return await _context.Libro.CountAsync(x=>x.autorId == id);
        }

        public async Task<Libro?> GetLibroById(int id)
        {
            return await _context.Libro.FindAsync(id);
        }

        public async Task<bool> UpdateLibro(Libro libro)
        {
            _context.ChangeTracker.Clear();
            _context.Libro.Update(libro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
