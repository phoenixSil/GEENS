using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses;
using Geens.Features.Dtos.Adresses;
using Geens.Features.Core.Commandes.Adresses;
using Geens.Features.Contrats.Repertoires;

namespace Geens.Features.Core.CommandHandlers.Adresses
{
    public class LireAdresseUniqueDunEnseignantCmdHdler : IRequestHandler<LireAdresseUniqueDunEnseignantCmd, AdresseDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireAdresseUniqueDunEnseignantCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<AdresseDetailDto> Handle(LireAdresseUniqueDunEnseignantCmd request, CancellationToken cancellationToken)
        {
            var adresse = await _pointDaccess.RepertoireDadresse.Lire(request.AdresseId);
            var adresseDetail = _mapper.Map<AdresseDetailDto>(adresse);

            return adresseDetail;
        }
    }
}
