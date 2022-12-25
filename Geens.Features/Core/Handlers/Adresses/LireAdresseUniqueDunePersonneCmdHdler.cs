using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses;
using Geens.Features.Dtos.Adresses;
using Geens.Features.Core.Commandes.Adresses;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;

namespace Geens.Features.Core.CommandHandlers.Adresses
{
    public class LireAdresseUniqueDunEnseignantCmdHdler : BaseCommandHandler<LireAdresseUniqueDunEnseignantCmd, AdresseDetailDto>
    {
        private readonly ILogger<LireAdresseUniqueDunEnseignantCmdHdler> _logger;

        public LireAdresseUniqueDunEnseignantCmdHdler(ILogger<LireAdresseUniqueDunEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<AdresseDetailDto> Handle(LireAdresseUniqueDunEnseignantCmd request, CancellationToken cancellationToken)
        {
            var adresse = await _pointDaccess.RepertoireDadresse.Lire(request.AdresseId);
            var adresseDetail = _mapper.Map<AdresseDetailDto>(adresse);

            return adresseDetail;
        }
    }
}
