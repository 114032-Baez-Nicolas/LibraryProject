using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CodeFirstLibraryDb.Models;

public class Libro
{
    [Key]
    public Guid ISBN { get; set; }

    [Required]
    public string Titulo { get; set; } 
    public DateTime FechaPublicacion { get; set; }

    [ForeignKey("IdAutorNavegation")]
    public int lAutorId { get; set; }
    public Autor IdAutorNavegation { get; set; } = null!;

    [ForeignKey("IdGeneroNavegation")]
    public int lGeneroId { get; set; }
    public Genero IdGeneroNavegation { get; set; } = null!;

}
