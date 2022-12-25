using AutoMapper;
using MediatR;
using Geens.Api.DTOs.Adresses.Validations;
using MsCommun.Exceptions;
using Geens.Domain.Modeles;
using MsCommun.Reponses;
using Geens.Features.Core.Commandes.Adresses;
using Geens.Features.Contrats.Repertoires;
using Geens.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;

namespace Geens.Features.Core.CommandHandlers.Adresses
{
    public class ModifierAdresseDunEnseignantCmdHdler : BaseCommandHandler<ModifierAdresseDunEnseignantCmd, ReponseDeRequette>
    {
        private readonly ILogger<ModifierAdresseDunEnseignantCmdHdler> _logger;

        public ModifierAdresseDunEnseignantCmdHdler(ILogger<ModifierAdresseDunEnseignantCmdHdler> logger, IMediator mediator, IMapper mapper, IPointDaccess pointDaccess) :
            base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async  Task<ReponseDeRequette> Handle(ModifierAdresseDunEnseignantCmd request, CancellationToken cancellationToken)
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
