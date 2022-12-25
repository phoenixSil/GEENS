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

namespace Geens.Features.Core.CommandHandlers.Enseignants
{
    public class SupprimerUnEnseignantCmdHdler : BaseCommandHandler<SupprimerUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly ILogger<SupprimerUnEnseignantCmdHdler> _logger;

        public SupprimerUnEnseignantCmdHdler(ILogger<SupprimerUnEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<ReponseDeRequette> Handle(SupprimerUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.Id);

            if (enseignant is null)
            {
                response.Success = true;
                response.Message = $"il n'existe pas d'enseignant d'Id {request.Id}";
                return response;
            } else
            {
                // synchronisation GDE => GDC
                //await _gdcProxy.SupprimerEnseignantAssocierDansGdc(request.Id);       

                var resultat = await _pointDaccess.RepertoireDenseignant.Supprimer(enseignant);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'enseignant d'Id [{request.Id}] a ete supprimer avec success ";
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                }
            }
            return response;
        }
    }
}
