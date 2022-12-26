using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants.Validations;
using Geens.Features.Core.Commandes.Enseignants;
using Geens.Domain.Modeles;
using MsCommun.Reponses;
using Geens.Features.Proxies.GdcProxys;
using Geens.Features.Proxies.GdcProxys.Contrats;
using Geens.Features.Contrats.Repertoires;
using Microsoft.Extensions.Logging;
using Geens.Features.Core.BaseFactoryClass;
using System.Net;
using MassTransit;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Enseignants;
using MsCommun.Messages.Utils;

namespace Geens.Features.Core.CommandHandlers.Enseignants
{
    public class AjouterUnEnseignantAUnEnseignantCmdHdler : BaseCommandHandler<AjouterUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly ILogger<AjouterUnEnseignantAUnEnseignantCmdHdler> _logger;
        private readonly IPublishEndpoint _publishEndPoint;

        public AjouterUnEnseignantAUnEnseignantCmdHdler(IPublishEndpoint publishEndPoint, ILogger<AjouterUnEnseignantAUnEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
            _publishEndPoint = publishEndPoint;
        }

        public override async  Task<ReponseDeRequette> Handle(AjouterUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("on vas ammorcer l'ajout d'un Enseignant dans le MS Enseignant");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDenseignantDto();
            var resultatValidation = await validateur.ValidateAsync(request.EnseignantAAjouterDto);

            if (resultatValidation.IsValid is false)
            {
                _logger.LogError("Une erreur de Validation: Des donnees ne sont pas conforme a ce qui est attendu.");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Enseignant a la enseignant donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
                reponse.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                _logger.LogInformation("Les donnees sont valides et on peut ammorcer la sauvegarde.");
                var enseignantACreer = _mapper.Map<Enseignant>(request.EnseignantAAjouterDto);
                var result = await _pointDaccess.RepertoireDenseignant.Ajoutter(enseignantACreer);

                _logger.LogInformation($"L'enseignant d'ID [{result.Id}] a ete bien enregistrer");

                if (result is null)
                {
                    _logger.LogError($"\"Echec de Lajout dune Enseignant..");
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Enseignant a la enseignant donc l'Id est notee dans le champs d'Id";
                    reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                else
                {
                    // synchronisation GDE => GDC
                    _logger.LogError($"on vas ajoutter lenseignant dans le MS de Gestion de Cours GDC");
                    // await _gdcProxy.AjouterUnEnseignant(result);

                    // Communication Asynchrone via le Bus Rabbit MQ
                    var dto = await GenerateDtoPourEnseignant(result).ConfigureAwait(false);
                    await _publishEndPoint.Publish(dto, cancellationToken).ConfigureAwait(false);

                    _logger.LogError($"Enregistrement de l'enseigant terminer ");
                    reponse.Success = true;
                    reponse.Message = "Ajout d'Enseignant Reussit";
                    reponse.Id = result.Id;
                    reponse.StatusCode = (int)HttpStatusCode.Created;
                }
            }

            return reponse;
        }


        #region PRIVATE FUNCTION

        private async Task<EnseignantACreerMessage> GenerateDtoPourEnseignant(Enseignant enseignant)
        {
            var enseignantDetail = await _pointDaccess.RepertoireDenseignant.LireDetailDunEnseignant(enseignant.Id);
            var enseignantMapper = _mapper.Map<EnseignantACreerMessage>(enseignantDetail);
            enseignantMapper.Service = DesignationService.SERVICE_GEENS;
            enseignantMapper.Type = TypeMessage.CREATION;
            return enseignantMapper;
        }

        #endregion
    }
}
