namespace CodeFirstLibraryDb.Dominio.LibrosDtos;

public class PutLibroDto
{
    public Guid ISBN { get; set; }
    public string Titulo { get; set; } = null!;
    public DateTime FechaPublicacion { get; set; }

    public int lAutorId { get; set; }
    public int lGeneroId { get; set; }
}
