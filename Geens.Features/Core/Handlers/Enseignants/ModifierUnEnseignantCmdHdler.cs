using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants.Validations;
using MsCommun.Reponses;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.Commandes.Enseignants;
using Geens.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;
using MassTransit;
using MsCommun.Messages.Utils;
using MsCommun.Messages.Enseignants;
using Newtonsoft.Json;
using System.Net;

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
            _logger.LogInformation($"On vas essayer de Modifier un Enseignant . Donness {JsonConvert.SerializeObject(request.EnseignantAModifierDto)}");
            var reponse = new ReponseDeRequette();
            var entiere = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);

            if (entiere is null)
            {
                reponse.Success = false;
                reponse.Message = "La entiere specifier est introuvable ";
                reponse.Id = request.EnseignantId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"la entiere nexsite pas Id : [{request.EnseignantId}]");
            }
            else
            {
                var validateur = new ValidateurDeLaModificationDenseignantDto();
                var resultatValidation = await validateur.ValidateAsync(request.EnseignantAModifierDto, cancellationToken);

                if (resultatValidation.IsValid is false)
                {
                    reponse.Success = false;
                    reponse.Message = "Les Donnees de la entiere ne sont pas valides  ";
                    reponse.Id = request.EnseignantId;
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError($"Les Donnees de la entiere ne sont pas valides : {JsonConvert.SerializeObject(request.EnseignantAModifierDto)}");
                }
                else
                {
                    _mapper.Map(request.EnseignantAModifierDto, entiere);

                    await _pointDaccess.RepertoireDenseignant.Modifier(entiere);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = entiere.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation($"Modification de la Enseignant Reussit ID: [{request.EnseignantId}]");

                    // deposer la entiere creer sur le Bus 
                    var dtoEnseignant = await GenerateDtoPourEnseignant(request.EnseignantId).ConfigureAwait(false);
                    await _publishEndPoint.Publish(dtoEnseignant, cancellationToken).ConfigureAwait(false);
                }
            }
            return reponse;
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
