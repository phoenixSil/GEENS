using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using Geens.Api.DTOs.Enseignants;
using Geens.Api.DTOs.Enseignants.Validations;
using MsCommun.Exceptions;
using Geens.Api.Features.Commandes.Enseignants;
using Geens.Api.Modeles;
using Geens.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Geens.Api.Proxies.GdcProxys;
using Geens.Api.Proxies.GdcProxys.Contrats;

namespace Geens.Api.Features.CommandHandlers.Enseignants
{
    public class ModifierUnEnseignantCmdHdler : IRequestHandler<ModifierUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IGdcProxy _gdcProxy;

        public ModifierUnEnseignantCmdHdler(IGdcProxy gdcProxy, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
            _gdcProxy = gdcProxy;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);

            if (enseignant is null)
                throw new NotFoundException(nameof(enseignant), request.EnseignantId);

            if (request.EnseignantAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDenseignantDto();
                var resultatValidation = await validateur.ValidateAsync(request.EnseignantAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDenseignant.Exists(request.EnseignantId))
                    throw new BadRequestException($"L'un des Ids Enseignant::[{request.EnseignantId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.EnseignantAModifierDto, enseignant);

                await _pointDaccess.RepertoireDenseignant.Modifier(enseignant);
                await _pointDaccess.Enregistrer();

                //await _gdcProxy.ModifierEnseignantDansGDC(enseignant);

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = enseignant.Id;

                return reponse;
            }
            throw new BadRequestException("enseignant a Modifier est null");
        }
    }

}
