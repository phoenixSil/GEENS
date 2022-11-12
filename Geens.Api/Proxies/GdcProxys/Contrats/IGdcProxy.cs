using Geens.Api.Modeles;
using Geens.Api.Modeles;
using MsCommun.Reponses;

namespace Geens.Api.Proxies.GdcProxys.Contrats
{
    public interface IGdcProxy
    {
        public Task<ReponseDeRequette> AjouterUnEnseignant(Enseignant enseignant);
    }
}
