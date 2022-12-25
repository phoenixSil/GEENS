using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Reponses;

namespace Geens.Features.Core.Commandes.Enseignants
{
    public class SupprimerUnEnseignantCmd: IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
