using MediatR;
using Geens.Api.Dtos.Adresses;
using Geens.Api.Modeles;
using MsCommun.Reponses;

namespace Geens.Api.Features.Commandes.Adresses
{
    public class SupprimerAdresseDunEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
    }
}
