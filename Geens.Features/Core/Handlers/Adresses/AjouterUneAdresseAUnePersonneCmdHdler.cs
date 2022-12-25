using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses.Validations;
using Geens.Domain.Modeles;
using MsCommun.Reponses;
using Geens.Features.Core.Commandes.Adresses;
using Geens.Features.Contrats.Repertoires;

namespace Geens.Features.Core.CommandHandlers.Adresses
{
    public class AjouterUneAdresseAUnEnseignantCmdHdler : IRequestHandler<AjouterUneAdresseAUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public AjouterUneAdresseAUnEnseignantCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUneAdresseAUnEnseignantCmd request, CancellationToken cancellationToken)
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
