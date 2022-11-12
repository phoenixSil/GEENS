using AutoMapper;
using MediatR;
using MsCommun.Exceptions;
using Geens.Api.Modeles;
using Geens.Api.Repertoires;
using Geens.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Geens.Api.Features.Commandes.Adresses;

namespace Geens.Api.Features.CommandHandlers.Adresses
{
    public class SupprimerAdresseDunEnseignantCmdHdler : IRequestHandler<SupprimerAdresseDunEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDAccess;
        public SupprimerAdresseDunEnseignantCmdHdler(IPointDaccess pointDAccess)
        {
            _pointDAccess = pointDAccess;
        }
        public async Task<ReponseDeRequette> Handle(SupprimerAdresseDunEnseignantCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var adresse = await _pointDAccess.RepertoireDadresse.Lire(request.AdresseId);

            //validation
            if (adresse is null)
                throw new NotFoundException(nameof(Adresse),request.AdresseId);

            var resultat = await _pointDAccess.RepertoireDadresse.Supprimer(adresse);

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
