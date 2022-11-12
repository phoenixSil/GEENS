using FluentValidation;
using Geens.Api.Dtos.Enseignants;
using Geens.Api.Repertoires.Contrats;

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
