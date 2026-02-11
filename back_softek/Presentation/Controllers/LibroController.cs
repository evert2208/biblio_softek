using back_softek.Application.Dtos;
using back_softek.Application.IServices;
using back_softek.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace back_softek.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost]
        public async Task<ActionResult<LibroDto>> CreateLibro([FromBody] CreateLibroDto dto)
        {
            var libro = await _libroService.CreateLibro(dto);
            return CreatedAtAction(nameof(CreateLibro), new { id = libro.id }, libro);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDto>>> GetAllLibros()
        {
            var libro = await _libroService.GetAllLibros();
            return Ok(libro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateLibro(int id, [FromBody] CreateLibroDto dto)
        {
            var libro = await _libroService.UpdateLibro(id, dto);
            return Ok( new
            {
                mensaje = $"Libro {dto.titulo} fue Actualizado Correctamente",
                status = libro
            }
                );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteLibro(int id)
        {
            var libro = await _libroService.DeleteLibro(id);
            return Ok(new
            {
                mensaje = "Libro Eliminado Correctamente",
                status = libro
            }
                );
        }
    }
}
