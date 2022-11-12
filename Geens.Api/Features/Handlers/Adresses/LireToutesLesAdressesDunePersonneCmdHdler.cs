using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses;
using MsCommun.Exceptions;
using Geens.Api.Modeles;
using Geens.Api.Repertoires.Contrats;
using Geens.Api.Core.Commandes.Adresses;
using Geens.Api.Dtos.Adresses;

namespace Geens.Api.Features.CommandHandlers.Adresses
{
    public class LireToutesLesAdressesDunEnseignantCmdHdler : IRequestHandler<LireToutesLesAdressesDunEnseignantCmd, List<AdresseDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireToutesLesAdressesDunEnseignantCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<AdresseDto>> Handle(LireToutesLesAdressesDunEnseignantCmd request, CancellationToken cancellationToken)
        {
            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);

            if (enseignant == null)
                throw new NotFoundException(nameof(Enseignant), request.EnseignantId);

            var listAdresse = _pointDaccess.RepertoireDadresse.LireToutesLesAdresseDunEnseignant(request.EnseignantId);

            var listAdresseDto = _mapper.Map<List<AdresseDto>>(listAdresse);

            return listAdresseDto;
        }
    }

    public class LreToutesLesAdressesCmdHdler : IRequestHandler<LreToutesLesAdressesCmd, List<AdresseDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LreToutesLesAdressesCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<AdresseDto>> Handle(LreToutesLesAdressesCmd request, CancellationToken cancellationToken)
        {
            var listAdresse = _pointDaccess.RepertoireDadresse.Lire();

            var listAdresseDto = _mapper.Map<List<AdresseDto>>(listAdresse);

            return listAdresseDto;
        }
    }
}
