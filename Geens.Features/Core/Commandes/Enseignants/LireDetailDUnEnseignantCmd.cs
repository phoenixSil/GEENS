using Geens.Features.Dtos.Enseignants;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using Geens.Features.Core.BaseFactoryClass;


namespace Geens.Features.Core.Commandes.Enseignants
{
    public class LireDetailDUnEnseignantCmd : BaseCommand<EnseignantDetailDto>
    {
        public Guid Id { get; set; }
    }
}
