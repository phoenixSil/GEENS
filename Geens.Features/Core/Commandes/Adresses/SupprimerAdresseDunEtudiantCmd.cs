using MediatR;
using Geens.Features.Dtos.Adresses;
using Geens.Domain.Modeles;
using MsCommun.Reponses;
using Geens.Features.Core.BaseFactoryClass;


namespace Geens.Features.Core.Commandes.Adresses
{
    public class SupprimerAdresseDunEnseignantCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
    }
}
