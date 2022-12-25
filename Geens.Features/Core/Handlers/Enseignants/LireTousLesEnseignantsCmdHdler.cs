using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Exceptions;
using Geens.Features.Core.Commandes.Enseignants;
using Geens.Domain.Modeles;
using Geens.Features.Dtos.Enseignants;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;

namespace Geens.Features.Core.CommandHandlers.Enseignants
{
    public class LireTousLesEnseignantsCmdHdler : BaseCommandHandler<LireTousLesEnseignantsCmd, List<EnseignantDto>>
    {
        private readonly ILogger<LireTousLesEnseignantsCmdHdler> _logger;

        public LireTousLesEnseignantsCmdHdler(ILogger<LireTousLesEnseignantsCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<List<EnseignantDto>> Handle(LireTousLesEnseignantsCmd request, CancellationToken cancellationToken)
        {

            var listEnseignant = await _pointDaccess.RepertoireDenseignant.Lire();

            var listEnseignantDto = _mapper.Map<List<EnseignantDto>>(listEnseignant);

            return listEnseignantDto;
        }
    }
}
