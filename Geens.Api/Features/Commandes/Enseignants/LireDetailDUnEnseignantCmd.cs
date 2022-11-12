using Geens.Api.Dtos.Enseignants;
using MediatR;
using Geens.Api.DTOs.Enseignants;

namespace Geens.Api.Features.Commandes.Enseignants
{
    public class LireDetailDUnEnseignantCmd : IRequest<EnseignantDetailDto>
    {
        public Guid Id { get; set; }
    }
}
