using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Reponses;
using Geens.Features.Dtos.Enseignants;

namespace Geens.Features.Core.Commandes.Enseignants
{
    public class AjouterUnEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public EnseignantACreerDto EnseignantAAjouterDto { get; set; }
    }
}
