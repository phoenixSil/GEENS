using AutoMapper;
using MediatR;
using MsCommun.Exceptions;
using Geens.Domain.Modeles;
using MsCommun.Reponses;
using Geens.Features.Core.Commandes.Adresses;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;

namespace Geens.Features.Core.CommandHandlers.Adresses
{
    public class SupprimerAdresseDunEnseignantCmdHdler : BaseCommandHandler<SupprimerAdresseDunEnseignantCmd, ReponseDeRequette>
    {
        private readonly ILogger<SupprimerAdresseDunEnseignantCmdHdler> _logger;

        public SupprimerAdresseDunEnseignantCmdHdler(ILogger<SupprimerAdresseDunEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<ReponseDeRequette> Handle(SupprimerAdresseDunEnseignantCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var adresse = await _pointDaccess.RepertoireDadresse.Lire(request.AdresseId);

            //validation
            if (adresse is null)
                throw new NotFoundException(nameof(Adresse),request.AdresseId);

            var resultat = await _pointDaccess.RepertoireDadresse.Supprimer(adresse);

            if (resultat == true)
            {
                response.Success = true;
                response.Message = $"l'adresse d'Id [{request.AdresseId}] a ete supprimer avec success ";
            }
            else
            {
                response.Success = false;
                response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
            }
            return response;
        }
    }
}
