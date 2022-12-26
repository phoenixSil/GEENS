using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Exceptions;
using Geens.Features.Core.Commandes.Enseignants;
using Geens.Domain.Modeles;
using MsCommun.Reponses;
using Geens.Features.Proxies.GdcProxys;
using Geens.Features.Proxies.GdcProxys.Contrats;
using Microsoft.Extensions.Logging;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.BaseFactoryClass;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Utils;
using MsCommun.Messages.Enseignants;
using MassTransit;
using System.Net;

namespace Geens.Features.Core.CommandHandlers.Enseignants
{
    public class SupprimerUnEnseignantCmdHdler : BaseCommandHandler<SupprimerUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly ILogger<SupprimerUnEnseignantCmdHdler> _logger;
        private readonly IPublishEndpoint _publishEndPoint;

        public SupprimerUnEnseignantCmdHdler(IPublishEndpoint publishEndPoint, ILogger<SupprimerUnEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
            _publishEndPoint = publishEndPoint;
        }

        public override async  Task<ReponseDeRequette> Handle(SupprimerUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();
            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.Id);

            if (enseignant is null)
            {
                response.Success = true;
                response.Message = $"il n'existe pas d'enseignant d'Id {request.Id}";
                response.StatusCode = (int)HttpStatusCode.NotFound;
            } 
            else 
            {
                // synchronisation GDE => GDC
                var resultat = await _pointDaccess.RepertoireDenseignant.Supprimer(enseignant);

                if (resultat is true)
                {
                    response.Success = true;
                    response.Message = $"l'enseignant a ete supprimer avec success ";
                    response.StatusCode = (int)HttpStatusCode.OK;

                    // Communication Asynchrone via le Bus Rabbit MQ
                    var dto = GenererEnseignantMessagePourLeBus(enseignant.Id);
                    await _publishEndPoint.Publish(dto, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }
            return response;
        }

        #region PRIVATE FUNCTION

        private static EnseignantASupprimerMessage GenererEnseignantMessagePourLeBus(Guid id)
        {
            var dto = new EnseignantASupprimerMessage
            {
                Service = DesignationService.SERVICE_GEENS,
                Id = id,
                Type = TypeMessage.SUPPRESSION
            };

            return dto;
        }

        #endregion
    }
}
