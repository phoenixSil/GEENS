using FluentValidation;
using Geens.Api.Dtos.Enseignants;
using Geens.Api.Repertoires.Contrats;

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
 