using MediatR;
using Geens.Features.Dtos.Adresses;
using MsCommun.Reponses;
using Geens.Features.Core.BaseFactoryClass;


namespace Geens.Features.Core.Commandes.Adresses
{
    public class AjouterUneAdresseAUnEnseignantCmd : BaseCommand<ReponseDeRequette>
    {
        public AdresseACreerDto AdresseACreerDto { get; set; }
    }
}
