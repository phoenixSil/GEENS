using FluentValidation;
using Geens.Features.Dtos.Adresses;
using Geens.Features.Contrats.Repertoires;

namespace Geens.Api.DTOs.Adresses.Validations
{
    public class ValidateurDeDtoDadresse: AbstractValidator<IAdresseDto>
    {
        private readonly IPointDaccess _pointDaccess;

        public ValidateurDeDtoDadresse(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Votre Email nes pas valide ");

            RuleFor(p => p.Pays)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Le nom du pays est au trop court")
                .MaximumLength(100).WithMessage("le nom du pays ne doit pas exceder les 100 caracteres");

            RuleFor(p => p.Ville)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Le nom de la ville est au trop court")
                .MaximumLength(100).WithMessage("le nom de la ville ne doit pas exceder les 100 caracteres");

            RuleFor(p => p.EnseignantId)
               .NotEmpty()
               .MustAsync(async (id, token) => {
                   var enseignantExists = await _pointDaccess.RepertoireDenseignant.Exists(id);
                   return enseignantExists;
               })
               .WithMessage($" l'enseignant nexiste pas dans la base de donnees  ");
        }
    }
}
