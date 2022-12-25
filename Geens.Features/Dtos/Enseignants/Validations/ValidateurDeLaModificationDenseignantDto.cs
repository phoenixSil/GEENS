using FluentValidation;
using Geens.Features.Dtos.Enseignants;

namespace Geens.Api.DTOs.Enseignants.Validations
{
    public class ValidateurDeLaModificationDenseignantDto: AbstractValidator<EnseignantAModifierDto>
    {
        public ValidateurDeLaModificationDenseignantDto()
        {

            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            RuleFor(x => x.Niveau)
                .NotEmpty();

            Include(new ValidateurDeDtoDenseignant());
        }
    }
}
 