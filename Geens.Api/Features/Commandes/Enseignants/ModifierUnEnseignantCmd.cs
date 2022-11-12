using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Reponses;
using Geens.Api.Dtos.Enseignants;

namespace Geens.Api.Features.Commandes.Enseignants
{
    public class ModifierUnEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public Guid EnseignantId { get; set; }
        public EnseignantAModifierDto EnseignantAModifierDto { get; set; }
    }
}
