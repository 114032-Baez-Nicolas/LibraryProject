using AutoMapper;
using CodeFirstLibraryDb.Context;
using CodeFirstLibraryDb.Dominio.GenerosDtos;
using CodeFirstLibraryDb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstLibraryDb.Repositories.Implementaciones;

public class GenerosRepository : IGenerosRepository
{
    private readonly LibraryDbContext _libraryDbContext;
    private readonly IMapper _mapper;

    public GenerosRepository(LibraryDbContext libraryDbContext, IMapper mapper)
    {
        _libraryDbContext = libraryDbContext;
        _mapper = mapper;
    }

    //1) Get all de todos los generos
    public async Task<IEnumerable<GetGenerosDto>> GetAllGeneros()
    {
        var generos = await _libraryDbContext.Generos.ToListAsync();
        return _mapper.Map<IEnumerable<GetGenerosDto>>(generos);
    }

}
