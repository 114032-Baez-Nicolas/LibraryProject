using CodeFirstLibraryDb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstLibraryDb.Dominio.LibrosDtos
{
    public class GetLibrosDto
    {
        public Guid ISBN { get; set; }
        public string Titulo { get; set; } = null!;
        public DateTime FechaPublicacion { get; set; }
        public string NombreAutor { get; set; } = null!;
        public string NombreGenero { get; set; } = null!;
    }
}
