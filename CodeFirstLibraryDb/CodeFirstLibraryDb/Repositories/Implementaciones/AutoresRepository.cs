using AutoMapper;
using CodeFirstLibraryDb.Context;
using CodeFirstLibraryDb.Dominio.AutoresDtos;
using CodeFirstLibraryDb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstLibraryDb.Repositories.Implementaciones;

public class AutoresRepository : IAutoresRepository
{
    private readonly LibraryDbContext _libraryDbContext;
    private readonly IMapper _mapper;

    public AutoresRepository(LibraryDbContext libraryDbContext, IMapper mapper)
    {
        _libraryDbContext = libraryDbContext;
        _mapper = mapper;

    }

    //1) Get all de todos los autores
    public async Task<IEnumerable<GetAutoresDto>> GetAllAutores()
    {
        var autores = await _libraryDbContext.Autores.ToListAsync();
        return _mapper.Map<IEnumerable<GetAutoresDto>>(autores);
    }
}
