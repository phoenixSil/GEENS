using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using Geens.Api.DTOs.Enseignants;
using Geens.Api.DTOs.Enseignants.Validations;
using MsCommun.Exceptions;
using Geens.Domain.Modeles;
using MsCommun.Reponses;
using Geens.Features.Proxies.GdcProxys;
using Geens.Features.Proxies.GdcProxys.Contrats;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.Commandes.Enseignants;
using Geens.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;
using MassTransit;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Utils;
using MsCommun.Messages.Enseignants;

namespace Geens.Features.Core.CommandHandlers.Enseignants
{
    public class ModifierUnEnseignantCmdHdler : BaseCommandHandler<ModifierUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly ILogger<ModifierUnEnseignantCmdHdler> _logger;
        private readonly IPublishEndpoint _publishEndPoint;

        public ModifierUnEnseignantCmdHdler(IPublishEndpoint publishEndPoint, ILogger<ModifierUnEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
            _publishEndPoint = publishEndPoint;
        }

        public override async  Task<ReponseDeRequette> Handle(ModifierUnEnseignantCmd request, CancellationToken cancellationToken)
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

                //await _gdcProxy.ModifierEnseignantDansGDC(enseignant);

                // Communication Asynchrone via le Bus Rabbit MQ
                var dto = await GenerateDtoPourEnseignant(enseignant.Id).ConfigureAwait(false);
                await _publishEndPoint.Publish(dto, cancellationToken).ConfigureAwait(false);

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = enseignant.Id;

                return reponse;
            }
            throw new BadRequestException("enseignant a Modifier est null");
        }

        #region PRIVATE FUNCTION

        private async Task<EnseignantAModifierMessage> GenerateDtoPourEnseignant(Guid id)
        {
            var enseignantDetail = await _pointDaccess.RepertoireDenseignant.LireDetailDunEnseignant(id);
            var enseignantMapper = _mapper.Map<EnseignantAModifierMessage>(enseignantDetail);
            enseignantMapper.Service = DesignationService.SERVICE_GEENS;
            enseignantMapper.Type = TypeMessage.MODIFICATION;
            return enseignantMapper;
        }

        #endregion
    }

}
