using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using Geens.Features.Core.Commandes.Enseignants;
using Geens.Features.Dtos.Enseignants;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;

namespace Geens.Features.Core.CommandHandlers.Enseignants
{
    public class LireDetailDUnEnseignantCmdHdler : BaseCommandHandler<LireDetailDUnEnseignantCmd, EnseignantDetailDto>
    {
        private readonly ILogger<LireDetailDUnEnseignantCmdHdler> _logger;

        public LireDetailDUnEnseignantCmdHdler(ILogger<LireDetailDUnEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<EnseignantDetailDto> Handle(LireDetailDUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            var enseignant = await _pointDaccess.RepertoireDenseignant.LireDetailDunEnseignant(request.Id);
            var EnseignantDetail = _mapper.Map<EnseignantDetailDto>(enseignant);

            return EnseignantDetail;
        }
    }
}
