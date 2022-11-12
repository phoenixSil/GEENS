using MediatR;
using Geens.Api.Dtos.Adresses;

namespace Geens.Api.Core.Commandes.Adresses
{
    public class LireToutesLesAdressesDunEnseignantCmd: IRequest<List<AdresseDto>>
    {
        public Guid EnseignantId { get; set; }
    }

    public class LreToutesLesAdressesCmd : IRequest<List<AdresseDto>>
    {    }
}
