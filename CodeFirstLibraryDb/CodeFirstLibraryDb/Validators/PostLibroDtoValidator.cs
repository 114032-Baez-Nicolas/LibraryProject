using CodeFirstLibraryDb.Dominio.LibrosDtos;
using FluentValidation;

namespace CodeFirstLibraryDb.Validators;

public class PostLibroDtoValidator : AbstractValidator<PostLibroDto>
{
    public PostLibroDtoValidator()
    {
        RuleFor(x => x.ISBN).NotEmpty().WithMessage("El ISBN es requerido");
        RuleFor(x => x.Titulo).NotEmpty().WithMessage("El título es requerido");
        RuleFor(x => x.FechaPublicacion).NotEmpty().WithMessage("La fecha de publicación es requerida");
        RuleFor(x => x.lAutorId).NotEmpty().WithMessage("El autor es requerido");
        RuleFor(x => x.lGeneroId).NotEmpty().WithMessage("El género es requerido");
    }
}
