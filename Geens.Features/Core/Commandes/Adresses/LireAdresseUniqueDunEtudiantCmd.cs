using MediatR;
using Geens.Features.Dtos.Adresses;
using Geens.Features.Core.BaseFactoryClass;


namespace Geens.Features.Core.Commandes.Adresses
{
    public class LireAdresseUniqueDunEnseignantCmd: BaseCommand<AdresseDetailDto>
    {
        public Guid EnseignantId { get; set; }
        public Guid AdresseId { get; set; }
    }
}
