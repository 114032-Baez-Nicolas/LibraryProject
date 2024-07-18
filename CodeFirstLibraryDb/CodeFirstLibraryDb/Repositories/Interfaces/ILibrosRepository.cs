using CodeFirstLibraryDb.Dominio.LibrosDtos;

namespace CodeFirstLibraryDb.Repositories.Interfaces
{
    public interface ILibrosRepository
    {
        //1) Get all de todos
        Task<IEnumerable<GetLibrosDto>> GetAllLibros();

        //2) Get by id
        Task<GetLibrosDto> GetLibroById(Guid id);

        //3) Create libro
        Task<PostLibroDto> CreateLibro(PostLibroDto libro);

        //4) Borrar libro
        Task DeleteLibro(Guid id);

        //5) Update libro
        Task<PutLibroDto> UpdateLibro(PutLibroDto libro);
    }
}
