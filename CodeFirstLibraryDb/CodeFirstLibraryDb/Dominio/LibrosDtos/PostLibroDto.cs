using CodeFirstLibraryDb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstLibraryDb.Dominio.LibrosDtos;

public class PostLibroDto
{
    public Guid ISBN { get; set; }
    public string Titulo { get; set; } = null!;
    public DateTime FechaPublicacion { get; set; }

    public int lAutorId { get; set; }
    public int lGeneroId { get; set; }
}
