using Geens.Features.Dtos.Enseignants;
using MsCommun.Reponses;
using Microsoft.AspNetCore.Mvc;
using Geens.Features.Contrats.Services;

namespace Geens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnseignantController : ControllerBase
    {
        private readonly IServiceDenseignant _service;
        private readonly ILogger<AdresseController> _logger;

        public EnseignantController(ILogger<AdresseController> logger, IServiceDenseignant service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnEnseignant(EnseignantACreerDto enseignantAAjouterDto)
        {
            _logger.LogInformation($"Controller :: {nameof(AjouterUnEnseignant)} ");
            var result = await _service.AjouterUnEnseignant(enseignantAAjouterDto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<EnseignantDto>>> LireTousLesEnseignants()
        {
            _logger.LogInformation($"Controller :: {nameof(LireTousLesEnseignants)} ");
            var result = await _service.LireTousLesEnseignants();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EnseignantDto>> LireUnEnseignant(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(LireUnEnseignant)} ");
            var result = await _service.LireDetailDunEnseignant(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnEnseignant(Guid enseignantId, EnseignantAModifierDto enseignantAModifierDto)
        {
            _logger.LogInformation($"Controller :: {nameof(ModifierUnEnseignant)} ");
            var resultat = await _service.ModifierUnEnseignant(enseignantId, enseignantAModifierDto);
            return Ok(resultat);
        }


        [HttpDelete("{enseignantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUnEnseignant(Guid enseignantId)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerUnEnseignant)} ");
            var resultat = await _service.SupprimerUnEnseignant(enseignantId);
            return Ok(resultat);
        }
    }
}
