using MediatR;
using Geens.Features.Dtos.Adresses;
using MsCommun.Reponses;
using Geens.Api.DTOs.Adresses;
using Geens.Features.Core.BaseFactoryClass;


namespace Geens.Features.Core.Commandes.Adresses
{
    public class ModifierAdresseDunEnseignantCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
        public AdresseAModifierDto AdresseAModifierDto { get; set; }
    }
}
