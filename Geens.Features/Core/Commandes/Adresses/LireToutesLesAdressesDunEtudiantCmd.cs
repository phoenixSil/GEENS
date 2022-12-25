using MediatR;
using Geens.Features.Dtos.Adresses;

namespace Geens.Features.Core.Commandes.Adresses
{
    public class LireToutesLesAdressesDunEnseignantCmd: IRequest<List<AdresseDto>>
    {
        public Guid EnseignantId { get; set; }
    }

    public class LreToutesLesAdressesCmd : IRequest<List<AdresseDto>>
    {    }
}
