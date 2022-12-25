using MediatR;
using Geens.Features.Dtos.Adresses;

namespace Geens.Features.Core.Commandes.Adresses
{
    public class LireAdresseUniqueDunEnseignantCmd: IRequest<AdresseDetailDto>
    {
        public Guid EnseignantId { get; set; }
        public Guid AdresseId { get; set; }
    }
}
