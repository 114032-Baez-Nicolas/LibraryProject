namespace CodeFirstLibraryDb.Models;

public class Autor
{
    public int id { get; set; }
    public string Nombre { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public List<Libro> Libros { get; set; } = null!;
}
