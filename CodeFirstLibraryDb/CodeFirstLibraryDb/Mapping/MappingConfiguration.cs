using AutoMapper;
using CodeFirstLibraryDb.Dominio.AutoresDtos;
using CodeFirstLibraryDb.Dominio.GenerosDtos;
using CodeFirstLibraryDb.Dominio.LibrosDtos;
using CodeFirstLibraryDb.Models;

namespace CodeFirstLibraryDb.Mapping;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        //-----GETS-----

        //1) Get all de todos los autores
        CreateMap<Autor, GetAutoresDto>().ReverseMap();

        //2) Get all de todos los generos
        CreateMap<Genero, GetGenerosDto>().ReverseMap();

        //-----POSTS-----

        //1) Post de un libro
        CreateMap<PostLibroDto, Libro>().ReverseMap();

        //-----PUTS-----

        //1) Put de un libro
        CreateMap<PutLibroDto, Libro>().ReverseMap();
    }
}
