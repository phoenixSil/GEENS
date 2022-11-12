﻿using Geens.Api.Dtos.Enseignants;
using MsCommun.Reponses;
using Geens.Api.DTOs.Enseignants;

namespace Geens.Api.Services.Contrats
{
    public interface IServiceDenseignant
    {
        public Task<List<EnseignantDto>> LireTousLesEnseignants();
        public Task<ReponseDeRequette> AjouterUnEnseignant(EnseignantACreerDto enseignantAAjouter);
        public Task<ReponseDeRequette> SupprimerUnEnseignant(Guid EnseignantId);
        public Task<EnseignantDetailDto> LireDetailDunEnseignant(Guid id);
        public Task<ReponseDeRequette> ModifierUnEnseignant(Guid enseignantId, EnseignantAModifierDto enseignantAModifierDto);

    }
}
