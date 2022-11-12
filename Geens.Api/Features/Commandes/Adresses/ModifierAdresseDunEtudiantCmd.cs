using MediatR;
using Geens.Api.Dtos.Adresses;
using MsCommun.Reponses;
using Geens.Api.DTOs.Adresses;

namespace Geens.Api.Features.Commandes.Adresses
{
    public class ModifierAdresseDunEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
        public AdresseAModifierDto AdresseAModifierDto { get; set; }
    }
}
