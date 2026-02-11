using back_softek.Application.Dtos;
using back_softek.Application.IServices;
using back_softek.Domain.Entities;
using back_softek.Domain.Exceptions;
using back_softek.Domain.IRepository;

namespace back_softek.Domain.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IAutorRepository _autorRepository;
        private int maxLibrosPermitidos = 2; //maximo de libro permitidos para crear un nuevo libro

        public LibroService(ILibroRepository libroRepository, IAutorRepository autorRepository) { 
            _libroRepository = libroRepository;
            _autorRepository = autorRepository;
        }

        public async Task<LibroDto> CreateLibro(CreateLibroDto dto)
        {
            var max = 0;
            var autor = await _autorRepository.GetAutorbyId(dto.autorId);
            if(autor == null) { 
                throw new AutorNotFoundException(); 
            }else
            {
                max = await _libroRepository.GetCantLibros(dto.autorId);
            }

            if (max >= maxLibrosPermitidos)
            {
                throw new LibroLimitMaxException();
            }

            var libro = new Libro
            {
                titulo = dto.titulo,
                año = dto.año,
                genero = dto.genero,
                numeroPaginas = dto.numeroPaginas,
                autorId = dto.autorId
            };
            var create = await _libroRepository.CreateLibro(libro);
            
            return MapToDto(create);

        }

        public async Task<bool> DeleteLibro(int id)
        {
            var libro = await _libroRepository.GetLibroById(id);

            if (libro == null)
            {
                throw new LibrorNotFoundException();
            }

            return await _libroRepository.DeleteLibro(libro);
           
        }

        public async Task<IEnumerable<LibroDto>> GetAllLibros()
        {
            var libros = await _libroRepository.GetAllLibros();
            return libros.Select(MapToDto);
        }

       

        public async Task<LibroDto?> GetLibroById(int id)
        {
            var libro = await _libroRepository.GetLibroById(id);
            if (libro == null)
            {
                throw new LibrorNotFoundException();
            }
            else
            {
                return MapToDto(libro);
            }

        }

        public async Task<bool> UpdateLibro(int id, CreateLibroDto dto)
        {
            var libro = await _libroRepository.GetLibroById(id);
            if (libro == null)
            {
                throw new LibrorNotFoundException();
            }

            var libroUpdate = new Libro
            {
                id = dto.id,
                titulo = dto.titulo,
                año = dto.año,
                genero = dto.genero,
                numeroPaginas = dto.numeroPaginas,
                autorId = dto.autorId
            };

            return  await _libroRepository.UpdateLibro(libroUpdate);
            
        }
        private LibroDto MapToDto(Libro libro)
        {
            return new LibroDto(
               libro.id,
               libro.titulo,
               libro.año,
               libro.genero,
               libro.numeroPaginas,
               libro.autorId
               
            );
        }
    }


}
