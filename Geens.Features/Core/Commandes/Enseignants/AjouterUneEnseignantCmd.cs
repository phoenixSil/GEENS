using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Reponses;
using Geens.Features.Core.BaseFactoryClass;

using Geens.Features.Dtos.Enseignants;

namespace Geens.Features.Core.Commandes.Enseignants
{
    public class AjouterUnEnseignantCmd : BaseCommand<ReponseDeRequette>
    {
        public EnseignantACreerDto EnseignantAAjouterDto { get; set; }
    }
}
