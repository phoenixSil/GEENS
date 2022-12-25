using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses.Validations;
using Geens.Domain.Modeles;
using MsCommun.Reponses;
using Geens.Features.Core.Commandes.Adresses;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.BaseFactoryClass;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace Geens.Features.Core.CommandHandlers.Adresses
{
    public class AjouterUneAdresseAUnEnseignantCmdHdler : BaseCommandHandler<AjouterUneAdresseAUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly ILogger<AjouterUneAdresseAUnEnseignantCmdHdler> _logger;

        public AjouterUneAdresseAUnEnseignantCmdHdler(ILogger<AjouterUneAdresseAUnEnseignantCmdHdler> logger,  IMediator mediator,  IMapper mapper, IPointDaccess pointDaccess):
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<ReponseDeRequette> Handle(AjouterUneAdresseAUnEnseignantCmd request, CancellationToken cancellationToken)
        {            
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDadresseDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.AdresseACreerDto);

            if(resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Adresse a la enseignant donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var adresseACreer = _mapper.Map<Adresse>(request.AdresseACreerDto);
                var result = await _pointDaccess.RepertoireDadresse.Ajoutter(adresseACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Adresse a la enseignant donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Enseignant Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
