using FluentValidation;
using Geens.Api.Dtos.Enseignants;
using Geens.Api.Repertoires.Contrats;

namespace Geens.Api.DTOs.Enseignants.Validations
{
    public class ValidateurDeDtoDenseignant: AbstractValidator<IEnseignantDto>
    {

        public ValidateurDeDtoDenseignant()
        {
            RuleFor(x => x.Nom)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100)
                .WithMessage("le Nom que vous avez entrer est incorrect ");

            RuleFor(x => x.Prenom)
               .NotEmpty()
               .MinimumLength(4)
               .MaximumLength(100)
               .WithMessage("le Nom que vous avez entrer est incorrect ");
        }
    }
}
