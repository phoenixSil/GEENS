using MediatR;
using Geens.Api.Dtos.Adresses;
using MsCommun.Reponses;

namespace Geens.Api.Features.Commandes.Adresses
{
    public class AjouterUneAdresseAUnEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public AdresseACreerDto AdresseACreerDto { get; set; }
    }
}
