using MediatR;
using Geens.Features.Dtos.Adresses;
using Geens.Domain.Modeles;
using MsCommun.Reponses;

namespace Geens.Features.Core.Commandes.Adresses
{
    public class SupprimerAdresseDunEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
    }
}
