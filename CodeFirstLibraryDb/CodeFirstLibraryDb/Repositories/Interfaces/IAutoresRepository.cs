using CodeFirstLibraryDb.Dominio.AutoresDtos;

namespace CodeFirstLibraryDb.Repositories.Interfaces;

public interface IAutoresRepository
{
    //1) Get all de todos los autores
    Task<IEnumerable<GetAutoresDto>> GetAllAutores();
}
