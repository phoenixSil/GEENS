using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Reponses;
using Geens.Features.Core.BaseFactoryClass;

namespace Geens.Features.Core.Commandes.Enseignants
{
    public class SupprimerUnEnseignantCmd: BaseCommand<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
