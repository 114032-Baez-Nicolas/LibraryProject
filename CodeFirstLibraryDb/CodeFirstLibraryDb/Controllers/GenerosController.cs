using CodeFirstLibraryDb.Dominio.GenerosDtos;
using CodeFirstLibraryDb.Repositories.Implementaciones;
using CodeFirstLibraryDb.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstLibraryDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGenerosRepository _generosRepository;

        public GenerosController(IGenerosRepository generosRepository)
        {
            _generosRepository = generosRepository;
        }

        //1) Get all de todos los generos
        [HttpGet("ObtenerTodosLosGeneros")]
        public async Task<ActionResult<IEnumerable<GetGenerosDto>>> GetAllGeneros()
        {
            var generos = await _generosRepository.GetAllGeneros();
            return Ok(generos);
        }

    }
}
