using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Reponses;
using Geens.Api.Dtos.Enseignants;

namespace Geens.Api.Features.Commandes.Enseignants
{
    public class AjouterUnEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public EnseignantACreerDto EnseignantAAjouterDto { get; set; }
    }
}
