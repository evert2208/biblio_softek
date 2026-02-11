using back_softek.Domain.Entities;
using back_softek.Domain.IRepository;
using back_softek.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace back_softek.Infrastructure.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly AppDbContext _context;

        public AutorRepository(AppDbContext context) { 
        
            _context = context;
        }

        public async Task<Autor> CreateAutor(Autor autor)
        {
           _context.Autor.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<IEnumerable<Autor>> GetAllAutores()
        {
            return await _context.Autor.OrderBy(x => x.nombre).ToListAsync();
        }

        public async Task<Autor?> GetAutorbyId(int id)
        {
           return await _context.Autor.FindAsync(id);
        }

        public async Task UpdateAutor(Autor autor)
        {
            _context.Autor.Update(autor);
            await _context.SaveChangesAsync();
            //return autor;
        }
    }
}
