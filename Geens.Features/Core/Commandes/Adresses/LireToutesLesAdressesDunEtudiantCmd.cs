using MediatR;
using Geens.Features.Dtos.Adresses;
using Geens.Features.Core.BaseFactoryClass;


namespace Geens.Features.Core.Commandes.Adresses
{
    public class LireToutesLesAdressesDunEnseignantCmd: BaseCommand<List<AdresseDto>>
    {
        public Guid EnseignantId { get; set; }
    }

    public class LreToutesLesAdressesCmd : BaseCommand<List<AdresseDto>>
    {    }
}
