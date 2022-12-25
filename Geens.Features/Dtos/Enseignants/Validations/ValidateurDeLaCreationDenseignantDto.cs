using FluentValidation;
using Geens.Features.Dtos.Enseignants;

namespace Geens.Api.DTOs.Enseignants.Validations
{
    public class ValidateurDeLaCreationDenseignantDto:  AbstractValidator<EnseignantACreerDto>
    {
        public ValidateurDeLaCreationDenseignantDto()
        {
            RuleFor(x => x.Niveau)
                .NotEmpty();

            Include(new ValidateurDeDtoDenseignant());
        }
    }
}
