using FluentValidation;
using Geens.Features.Dtos.Adresses;
using Geens.Features.Contrats.Repertoires;

namespace Geens.Api.DTOs.Adresses.Validations
{
    public class ValidateurDeLaCreationDadresseDto:  AbstractValidator<AdresseACreerDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaCreationDadresseDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            Include(new ValidateurDeDtoDadresse(_pointDaccess));
        }
    }
}
