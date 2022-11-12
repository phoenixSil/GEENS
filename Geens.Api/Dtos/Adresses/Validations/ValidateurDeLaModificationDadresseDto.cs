using FluentValidation;
using Geens.Api.Dtos.Adresses;
using Geens.Api.DTOs.Adresses;
using Geens.Api.Repertoires.Contrats;

namespace Geens.Api.DTOs.Adresses.Validations
{
    public class ValidateurDeLaModificationDadresseDto: AbstractValidator<AdresseAModifierDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaModificationDadresseDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDadresse(_pointDaccess));
        }
    }
}
 