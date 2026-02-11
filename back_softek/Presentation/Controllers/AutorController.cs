using back_softek.Application.Dtos;
using back_softek.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace back_softek.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpPost]
        public async Task<ActionResult<AutorDto>> CreateAutor([FromBody] CreateAutorDto dto)
        {
            var autor = await _autorService.CreateAutor(dto);
            return CreatedAtAction(nameof(CreateAutor), new { id = autor.id }, autor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDto>>> GetAllAutores()
        {
            var autor = await _autorService.GetAllAutores();
            return Ok(autor);
        }

    }
}
