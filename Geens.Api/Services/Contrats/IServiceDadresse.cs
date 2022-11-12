using Geens.Api.Dtos.Adresses;
using MsCommun.Reponses;

namespace Geens.Api.Services.Contrats
{
    public interface IServiceDadresse
    {
        public Task<List<AdresseDto>> LireToutesLesAdresseDunEnseignant(Guid enseignantId);
        public Task<AdresseDetailDto> LireAdresseUniqueDunEnseignant(Guid adresseId);
        public Task<ReponseDeRequette> ModifierAdresseDunEnseignant(Guid adresseId, AdresseAModifierDto adresseDto);
        public Task<ReponseDeRequette> AjouterUneAdresseAUnEnseignant(AdresseACreerDto adresseDto);
        public Task<List<ReponseDeRequette>> AjouterUneListeDAdresseAUnEnseignant(List<AdresseACreerDto> adresseDto);
        public Task<ReponseDeRequette> SupprimerAdresseDunEnseignant(Guid adresseId);
        public Task<List<AdresseDto>> LireToutesLesAdresses();
    }
}
