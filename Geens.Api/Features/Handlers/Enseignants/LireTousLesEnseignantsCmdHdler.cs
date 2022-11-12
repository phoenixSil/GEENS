using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Exceptions;
using Geens.Api.Features.Commandes.Enseignants;
using Geens.Api.Modeles;
using Geens.Api.Repertoires.Contrats;
using Geens.Api.Dtos.Enseignants;

namespace Geens.Api.Features.CommandHandlers.Enseignants
{
    public class LireTousLesEnseignantsCmdHdler : IRequestHandler<LireTousLesEnseignantsCmd, List<EnseignantDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesEnseignantsCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<EnseignantDto>> Handle(LireTousLesEnseignantsCmd request, CancellationToken cancellationToken)
        {

            var listEnseignant = await _pointDaccess.RepertoireDenseignant.Lire();

            var listEnseignantDto = _mapper.Map<List<EnseignantDto>>(listEnseignant);

            return listEnseignantDto;
        }
    }
}
