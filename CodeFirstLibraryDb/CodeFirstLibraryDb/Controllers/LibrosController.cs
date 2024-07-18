using CodeFirstLibraryDb.Dominio.LibrosDtos;
using CodeFirstLibraryDb.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstLibraryDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosRepository _librosRepository;

        public LibrosController(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        //1) Get all de todos los libros
        [HttpGet("ObtenerTodosLosLibros")]
        public async Task<IEnumerable<GetLibrosDto>> GetAllLibros()
        {
            return await _librosRepository.GetAllLibros();
        }

        //2) Get libros by id
        [HttpGet("GetLibroById/{id}")]
        public async Task<GetLibrosDto> GetLibroById(Guid id)
        {
            return await _librosRepository.GetLibroById(id);
        }

        //3) Create libro
        [HttpPost("CrearLibro")]
        public async Task<ActionResult<PostLibroDto>> CreateLibro([FromBody] PostLibroDto libro)
        {
            var libroCreado = await _librosRepository.CreateLibro(libro);
            return Ok(libroCreado);
        }

        //4) Borrar libro
        [HttpDelete("DeleteLibro/{id}")]
        public async Task<ActionResult> DeleteLibro(Guid id)
        {
            await _librosRepository.DeleteLibro(id);
            return NoContent();
        }

        //5) Update libro
        [HttpPut("UpdateLibro")]
        public async Task<ActionResult<PutLibroDto>> UpdateLibro([FromBody] PutLibroDto libro)
        {
            var libroActualizado = await _librosRepository.UpdateLibro(libro);
            return Ok(libroActualizado);
        }
    }
}
