using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using Geens.Api.Features.Commandes.Enseignants;
using Geens.Api.Repertoires.Contrats;
using Geens.Api.Dtos.Enseignants;

namespace Geens.Api.Features.CommandHandlers.Enseignants
{
    public class LireDetailDUnEnseignantCmdHdler : IRequestHandler<LireDetailDUnEnseignantCmd, EnseignantDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUnEnseignantCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<EnseignantDetailDto> Handle(LireDetailDUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            var enseignant = await _pointDaccess.RepertoireDenseignant.LireDetailDunEnseignant(request.Id);
            var EnseignantDetail = _mapper.Map<EnseignantDetailDto>(enseignant);

            return EnseignantDetail;
        }
    }
}
