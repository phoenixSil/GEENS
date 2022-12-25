using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Reponses;
using Geens.Features.Dtos.Enseignants;

namespace Geens.Features.Core.Commandes.Enseignants
{
    public class ModifierUnEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public Guid EnseignantId { get; set; }
        public EnseignantAModifierDto EnseignantAModifierDto { get; set; }
    }
}
