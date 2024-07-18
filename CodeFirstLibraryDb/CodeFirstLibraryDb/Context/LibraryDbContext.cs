using CodeFirstLibraryDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CodeFirstLibraryDb.Context;

public class LibraryDbContext : DbContext
{

    public LibraryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Libro> Libros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>().HasData(
                       new Autor { id = 1, Nombre = "Gabriel García Márquez", FechaNacimiento = new DateTime(1927, 3, 6) },
                       new Autor { id = 2, Nombre = "Julio Cortázar", FechaNacimiento = new DateTime(1914, 8, 26) },
                       new Autor { id = 3, Nombre = "Mario Vargas Llosa", FechaNacimiento = new DateTime(1936, 3, 28) }
       );

        modelBuilder.Entity<Genero>().HasData(
                       new Genero { id = 1, Nombre = "Realismo Mágico" },
                       new Genero { id = 2, Nombre = "Novela" },
                       new Genero { id = 3, Nombre = "Cuento" }
       );

        modelBuilder.Entity<Libro>().HasData(
                       new Libro { ISBN = Guid.NewGuid(), Titulo = "Cien años de soledad", FechaPublicacion = new DateTime(1967, 5, 30), lAutorId = 1, lGeneroId = 1 },
                       new Libro { ISBN = Guid.NewGuid(), Titulo = "Rayuela", FechaPublicacion = new DateTime(1963, 6, 28), lAutorId = 2, lGeneroId = 2 },
                       new Libro { ISBN = Guid.NewGuid(), Titulo = "La ciudad y los perros", FechaPublicacion = new DateTime(1963, 6, 28), lAutorId = 3, lGeneroId = 3 }

       );


    }
}
