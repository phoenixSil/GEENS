using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses;
using Geens.Api.Repertoires.Contrats;
using Geens.Api.Dtos.Adresses;
using Geens.Api.Features.Commandes.Adresses;

namespace Geens.Api.Features.CommandHandlers.Adresses
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
