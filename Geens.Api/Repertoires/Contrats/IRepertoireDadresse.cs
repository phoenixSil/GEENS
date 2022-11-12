using Geens.Api.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Geens.Api.Repertoires.Contrats
{
    public interface IRepertoireDadresse : IRepertoireGenerique<Adresse>
    {
        public Task<List<Adresse>> LireToutesLesAdresseDunEnseignant(Guid eutiantId);

    }
}
