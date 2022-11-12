using MediatR;
using Geens.Api.Dtos.Adresses;

namespace Geens.Api.Features.Commandes.Adresses
{
    public class LireAdresseUniqueDunEnseignantCmd: IRequest<AdresseDetailDto>
    {
        public Guid EnseignantId { get; set; }
        public Guid AdresseId { get; set; }
    }
}
