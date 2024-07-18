namespace CodeFirstLibraryDb.Models;

public class Genero
{
    public int id { get; set; }
    public string Nombre { get; set; } = null!;
    public List<Libro> Libros { get; set; } = null!; 

}
