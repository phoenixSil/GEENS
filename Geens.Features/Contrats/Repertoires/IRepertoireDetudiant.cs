using Geens.Domain.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Geens.Features.Contrats.Repertoires
{
    public interface IRepertoireDenseignant : IRepertoireGenerique<Enseignant>
    {
        public Task<Enseignant> LireDetailDunEnseignant(Guid id);
    }
}
