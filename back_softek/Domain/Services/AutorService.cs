using back_softek.Application.Dtos;
using back_softek.Application.IServices;
using back_softek.Domain.Entities;
using back_softek.Domain.Exceptions;
using back_softek.Domain.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;

namespace back_softek.Domain.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<AutorDto> CreateAutor(CreateAutorDto dto)
        {
            
            var autor = new Autor
            {
                nombre = dto.nombre,
                fechaNac = dto.fechaNac,
                ciudadProcedencia = dto.ciudadProcedencia,
                correo = dto.correo
                
            };

            var create = await _autorRepository.CreateAutor(autor);

            return new AutorDto(
               create.id,
               create.nombre,
               create.correo,
               create.fechaNac,
               create.ciudadProcedencia
            );
        }

        public async Task<IEnumerable<AutorDto>> GetAllAutores()
        {
            var autores =  await _autorRepository.GetAllAutores();
            return autores.Select(MapToDto);
        }

        public async Task<AutorDto?> GetAutorbyId(int id)
        {
            var autor = await _autorRepository.GetAutorbyId(id);
            if (autor == null) {
                throw new AutorNotFoundException(); 
            }
            else {
                return MapToDto(autor);
            }
        }

        public async Task UpdateAutor(int id, CreateAutorDto dto)
        {
            var autor = await _autorRepository.GetAutorbyId(id);
            if (autor == null)
            {
                throw new AutorNotFoundException();
            }
            else
            {
                await _autorRepository.UpdateAutor(autor);
            }
        }

        private AutorDto MapToDto(Autor autor)
        {
            return new AutorDto(
               autor.id,
               autor.nombre,
               autor.correo,
               autor.fechaNac,
               autor.ciudadProcedencia
            );
        }
    }
}
