using Geens.Features.Dtos.Enseignants;
using MsCommun.Reponses;
using Geens.Features.Contrats.Services;
using MediatR;
using Geens.Features.Core.Commandes.Enseignants;

namespace Geens.Application.Services
{
    public class ServiceDenseignant : IServiceDenseignant
    {
        private readonly IMediator _mediator;
        public ServiceDenseignant(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUnEnseignant(EnseignantACreerDto enseignantAAjouter)
        {
            var resultatAjoutEnseignant = await _mediator.Send(new AjouterUnEnseignantCmd { EnseignantAAjouterDto = enseignantAAjouter });
            return resultatAjoutEnseignant;
        }

        public async Task<EnseignantDetailDto> LireDetailDunEnseignant(Guid id)
        {
            var enseignant = await _mediator.Send(new LireDetailDUnEnseignantCmd { Id = id });
            return enseignant;
        }

        public async Task<List<EnseignantDto>> LireTousLesEnseignants()
        {
            var listEnseignant = await _mediator.Send(new LireTousLesEnseignantsCmd { });
            return listEnseignant;
        }

        public async Task<ReponseDeRequette> SupprimerUnEnseignant(Guid EnseignantId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUnEnseignantCmd { Id = EnseignantId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUnEnseignant(Guid enseignantId, EnseignantAModifierDto enseignantAModifier)
        {
           
            var resultatEnseignantAModifier = await _mediator.Send(new ModifierUnEnseignantCmd { EnseignantAModifierDto = enseignantAModifier });
            return resultatEnseignantAModifier;
        }
    }
}
