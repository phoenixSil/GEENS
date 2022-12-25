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

namespace Geens.Features.Core.CommandHandlers.Enseignants
{
    public class AjouterUnEnseignantAUnEnseignantCmdHdler : IRequestHandler<AjouterUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IGdcProxy _gdcProxy;
        private readonly ILogger<AjouterUnEnseignantAUnEnseignantCmdHdler> _logger;

        public AjouterUnEnseignantAUnEnseignantCmdHdler(IMediator mediator, IGdcProxy gdcProxy, ILogger<AjouterUnEnseignantAUnEnseignantCmdHdler> logger, IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _mediator = mediator;
            _gdcProxy = gdcProxy;
            _logger = logger;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("on vas ammorcer l'ajout d'un Enseignant dans le MS Enseignant");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDenseignantDto();
            var resultatValidation = await validateur.ValidateAsync(request.EnseignantAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                _logger.LogError("Une erreur de Validation: Des donnees ne sont pas conforme a ce qui est attendu.");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Enseignant a la enseignant donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                _logger.LogInformation("Les donnees sont valides et on peut ammorcer la sauvegarde.");
                var enseignantACreer = _mapper.Map<Enseignant>(request.EnseignantAAjouterDto);
                var result = await _pointDaccess.RepertoireDenseignant.Ajoutter(enseignantACreer);
                await _pointDaccess.Enregistrer();
                _logger.LogInformation($"L'enseignant d'ID [{result.Id}] a ete bien enregistrer");

                if (result == null)
                {
                    _logger.LogError($"\"Echec de Lajout dune Enseignant..");
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Enseignant a la enseignant donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    // synchronisation GDE => GDC
                    _logger.LogError($"on vas ajoutter lenseignant dans le MS de Gestion de Cours GDC");
                     // await _gdcProxy.AjouterUnEnseignant(result);

                    _logger.LogError($"Enregistrement de l'enseigant terminer ");
                    reponse.Success = true;
                    reponse.Message = "Ajout d'Enseignant Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
