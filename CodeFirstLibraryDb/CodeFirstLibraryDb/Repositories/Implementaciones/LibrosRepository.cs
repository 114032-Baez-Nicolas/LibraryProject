using AutoMapper;
using CodeFirstLibraryDb.Context;
using CodeFirstLibraryDb.Dominio.LibrosDtos;
using CodeFirstLibraryDb.Models;
using CodeFirstLibraryDb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstLibraryDb.Repositories.Implementaciones;

public class LibrosRepository : ILibrosRepository
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;

    public LibrosRepository(LibraryDbContext libraryDbContext, IMapper mapper)
    {
        _context = libraryDbContext;
        _mapper = mapper;
    }

    //1) Get all de todos los libros
    public async Task<IEnumerable<GetLibrosDto>> GetAllLibros()
    {
        return await _context.Libros.Select(x => new GetLibrosDto
        {
            ISBN = x.ISBN,
            Titulo = x.Titulo,
            FechaPublicacion = x.FechaPublicacion,
            NombreAutor = x.IdAutorNavegation.Nombre,
            NombreGenero = x.IdGeneroNavegation.Nombre

        }).ToListAsync();
    }

    //2) Get libros by id
    public async Task<GetLibrosDto> GetLibroById(Guid id)
    {
        return await _context.Libros.Where(x => x.ISBN == id).Select(x => new GetLibrosDto
        {
            ISBN = x.ISBN,
            Titulo = x.Titulo,
            FechaPublicacion = x.FechaPublicacion,
            NombreAutor = x.IdAutorNavegation.Nombre,
            NombreGenero = x.IdGeneroNavegation.Nombre

        }).FirstOrDefaultAsync();

    }

    //3) Create libro
    public async Task<PostLibroDto> CreateLibro(PostLibroDto libro)
    {
        var libroNuevo = _mapper.Map<Libro>(libro);
        libroNuevo.ISBN = Guid.NewGuid();

        _context.Libros.Add(libroNuevo);
        await _context.SaveChangesAsync();
        return _mapper.Map<PostLibroDto>(libroNuevo);
    }

    //4) Borrar libro
    public async Task DeleteLibro(Guid id)
    {
        var libro = await _context.Libros.FindAsync(id);
        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();
    }

    //5) Update libro
    public async Task<PutLibroDto> UpdateLibro(PutLibroDto libro)
    {
        var libroActualizado = _mapper.Map<Libro>(libro);
        _context.Entry(libroActualizado).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return _mapper.Map<PutLibroDto>(libroActualizado);
    }


}
