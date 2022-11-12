using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses.Validations;
using MsCommun.Exceptions;
using Geens.Api.Modeles;
using Geens.Api.Repertoires;
using Geens.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Geens.Api.Features.Commandes.Adresses;

namespace Geens.Api.Features.CommandHandlers.Adresses
{
    public class ModifierAdresseDunEnseignantCmdHdler : IRequestHandler<ModifierAdresseDunEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ModifierAdresseDunEnseignantCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ReponseDeRequette> Handle(ModifierAdresseDunEnseignantCmd request, CancellationToken cancellationToken)
        {

            var adresse = await _pointDaccess.RepertoireDadresse.Lire(request.AdresseId);

            if (adresse is null)
                throw new NotFoundException(nameof(adresse), request.AdresseId);

            if(request.AdresseAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDadresseDto(_pointDaccess);
                var resultatValidation = await validateur.ValidateAsync(request.AdresseAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDadresse.Exists(request.AdresseId))
                    throw new BadRequestException($"L'un des Ids Adresse::[{request.AdresseId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.AdresseAModifierDto, adresse);

                await _pointDaccess.RepertoireDadresse.Modifier(adresse);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = adresse.Id;

                return reponse;

            }

            throw new BadRequestException("adresse a Modifier est null");

        }
    }
}
