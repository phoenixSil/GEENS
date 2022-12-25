using Geens.Domain.Modeles;
using Geens.Domain.Modeles;
using MsCommun.Reponses;

namespace Geens.Features.Proxies.GdcProxys.Contrats
{
    public interface IGdcProxy
    {
        public Task<ReponseDeRequette> AjouterUnEnseignant(Enseignant enseignant);
    }
}
