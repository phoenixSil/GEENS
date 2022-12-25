using Geens.Domain.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Geens.Features.Contrats.Repertoires
{
    public interface IRepertoireDadresse : IRepertoireGenerique<Adresse>
    {
        public Task<List<Adresse>> LireToutesLesAdresseDunEnseignant(Guid eutiantId);

    }
}
