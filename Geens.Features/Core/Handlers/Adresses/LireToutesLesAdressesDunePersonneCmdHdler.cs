using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses;
using MsCommun.Exceptions;
using Geens.Domain.Modeles;
using Geens.Features.Core.Commandes.Adresses;
using Geens.Features.Dtos.Adresses;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;

namespace Geens.Features.Core.CommandHandlers.Adresses
{
    public class LireToutesLesAdressesDunEnseignantCmdHdler : BaseCommandHandler<LireToutesLesAdressesDunEnseignantCmd, List<AdresseDto>>
    {
        private readonly ILogger<LireToutesLesAdressesDunEnseignantCmdHdler> _logger;

        public LireToutesLesAdressesDunEnseignantCmdHdler(ILogger<LireToutesLesAdressesDunEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<List<AdresseDto>> Handle(LireToutesLesAdressesDunEnseignantCmd request, CancellationToken cancellationToken)
        {
            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);

            if (enseignant == null)
                throw new NotFoundException(nameof(Enseignant), request.EnseignantId);

            var listAdresse = _pointDaccess.RepertoireDadresse.LireToutesLesAdresseDunEnseignant(request.EnseignantId);

            var listAdresseDto = _mapper.Map<List<AdresseDto>>(listAdresse);

            return listAdresseDto;
        }
    }

    public class LreToutesLesAdressesCmdHdler : BaseCommandHandler<LreToutesLesAdressesCmd, List<AdresseDto>>
    {
        private readonly ILogger<LreToutesLesAdressesCmdHdler> _logger;

        public LreToutesLesAdressesCmdHdler(ILogger<LreToutesLesAdressesCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<List<AdresseDto>> Handle(LreToutesLesAdressesCmd request, CancellationToken cancellationToken)
        {
            var listAdresse = _pointDaccess.RepertoireDadresse.Lire();

            var listAdresseDto = _mapper.Map<List<AdresseDto>>(listAdresse);

            return listAdresseDto;
        }
    }
}
