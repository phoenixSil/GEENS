using Geens.Api.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Geens.Api.Repertoires.Contrats
{
    public interface IRepertoireDenseignant : IRepertoireGenerique<Enseignant>
    {
        public Task<Enseignant> LireDetailDunEnseignant(Guid id);
    }
}
