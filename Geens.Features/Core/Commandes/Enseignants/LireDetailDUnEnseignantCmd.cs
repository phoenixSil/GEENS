using Geens.Features.Dtos.Enseignants;
using MediatR;
using Geens.Api.DTOs.Enseignants;

namespace Geens.Features.Core.Commandes.Enseignants
{
    public class LireDetailDUnEnseignantCmd : IRequest<EnseignantDetailDto>
    {
        public Guid Id { get; set; }
    }
}
