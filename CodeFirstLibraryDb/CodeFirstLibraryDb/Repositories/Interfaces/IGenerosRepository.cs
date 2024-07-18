using CodeFirstLibraryDb.Dominio.GenerosDtos;

namespace CodeFirstLibraryDb.Repositories.Interfaces;

public interface IGenerosRepository
{
    //1) Get all de todos los generos
    Task<IEnumerable<GetGenerosDto>> GetAllGeneros();
}
