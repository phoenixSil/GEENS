using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Reponses;
using Geens.Features.Dtos.Enseignants;
using Geens.Features.Core.BaseFactoryClass;


namespace Geens.Features.Core.Commandes.Enseignants
{
    public class ModifierUnEnseignantCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid EnseignantId { get; set; }
        public EnseignantAModifierDto EnseignantAModifierDto { get; set; }
    }
}
