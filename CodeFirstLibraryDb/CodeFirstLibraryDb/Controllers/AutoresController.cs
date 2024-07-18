using CodeFirstLibraryDb.Dominio.AutoresDtos;
using CodeFirstLibraryDb.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstLibraryDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresRepository _autoresRepository;

        public AutoresController(IAutoresRepository autoresRepository)
        {
            _autoresRepository = autoresRepository;
        }

        //1) Get all de todos los autores
        [HttpGet("ObtenerTodosLosAutores")]
        public async Task<ActionResult<IEnumerable<GetAutoresDto>>> GetAllAutores()
        {
            var autores = await _autoresRepository.GetAllAutores();
            return Ok(autores);
        }
    }
}
