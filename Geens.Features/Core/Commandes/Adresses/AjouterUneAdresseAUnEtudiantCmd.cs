using MediatR;
using Geens.Features.Dtos.Adresses;
using MsCommun.Reponses;

namespace Geens.Features.Core.Commandes.Adresses
{
    public class AjouterUneAdresseAUnEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public AdresseACreerDto AdresseACreerDto { get; set; }
    }
}
