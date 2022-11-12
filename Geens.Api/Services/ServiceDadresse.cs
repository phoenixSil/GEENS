using Geens.Api.Core.Commandes.Adresses;
using Geens.Api.Dtos.Adresses;
using Geens.Api.DTOs.Adresses;
using Geens.Api.Features.Commandes.Adresses;
using MsCommun.Reponses;
using Geens.Api.Services.Contrats;
using MediatR;
using Geens.Api.DTOs.Adresses;
using Geens.Api.Modeles;

namespace Geens.Api.Services
{
    public class ServiceDadresse: IServiceDadresse
    {
        private readonly IMediator _mediator;
        public ServiceDadresse(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<ReponseDeRequette> AjouterUneAdresseAUnEnseignant(AdresseACreerDto adresseDto)
        {
            var response = await _mediator.Send(new AjouterUneAdresseAUnEnseignantCmd { AdresseACreerDto = adresseDto });
            return response;
        }

        public async Task<List<ReponseDeRequette>> AjouterUneListeDAdresseAUnEnseignant(List<AdresseACreerDto> adresseDto)
        {
            var responseList = new List<ReponseDeRequette>();

            foreach (var adresseACreer in adresseDto)
            {
                responseList.Add(await AjouterUneAdresseAUnEnseignant(adresseACreer));
            }

            return responseList;
        }

        public async Task<AdresseDetailDto> LireAdresseUniqueDunEnseignant(Guid adresseId)
        {
            var response = await _mediator.Send(new LireAdresseUniqueDunEnseignantCmd { AdresseId = adresseId });
            return response;
        }

        public async Task<List<AdresseDto>> LireToutesLesAdresseDunEnseignant(Guid enseignantId)
        {
            var response = await _mediator.Send(new LireToutesLesAdressesDunEnseignantCmd { EnseignantId = enseignantId });
            return response;
        }

        public async Task<List<AdresseDto>> LireToutesLesAdresses()
        {
            var response = await _mediator.Send(new LreToutesLesAdressesCmd { });
            return response;
        }

        public async Task<ReponseDeRequette> ModifierAdresseDunEnseignant(Guid adresseId, AdresseAModifierDto adresseDto)
        {
            var response = await _mediator.Send(new ModifierAdresseDunEnseignantCmd { AdresseId = adresseId, AdresseAModifierDto = adresseDto });
            return response;
        }


        public async Task<ReponseDeRequette> SupprimerAdresseDunEnseignant(Guid adresseId)
        {
            var response = await _mediator.Send(new SupprimerAdresseDunEnseignantCmd { AdresseId = adresseId });
            return response;
        }
    }
}