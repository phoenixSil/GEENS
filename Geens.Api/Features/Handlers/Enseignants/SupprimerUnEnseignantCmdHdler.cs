using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Exceptions;
using Geens.Api.Features.Commandes.Enseignants;
using Geens.Api.Modeles;
using Geens.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Geens.Api.Proxies.GdcProxys;
using Geens.Api.Proxies.GdcProxys.Contrats;

namespace Geens.Api.Features.CommandHandlers.Enseignants
{
    public class SupprimerUnEnseignantCmdHdler : IRequestHandler<SupprimerUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IGdcProxy _gdcProxy;
        private readonly ILogger<AjouterUnEnseignantAUnEnseignantCmdHdler> _logger;

        public SupprimerUnEnseignantCmdHdler(IMediator mediator, IGdcProxy gdcProxy, ILogger<AjouterUnEnseignantAUnEnseignantCmdHdler> logger, IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _mediator = mediator;
            _gdcProxy = gdcProxy;
            _logger = logger;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUnEnseignantCmd request, CancellationToken cancellationToken)
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
