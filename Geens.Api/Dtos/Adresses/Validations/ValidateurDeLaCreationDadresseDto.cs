using FluentValidation;
using Geens.Api.Dtos.Adresses;
using Geens.Api.Repertoires.Contrats;

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
