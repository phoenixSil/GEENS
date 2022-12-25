using Geens.Features.Dtos.Adresses;
using Geens.Api.DTOs.Adresses;
using MsCommun.Reponses;
using Geens.Features.Contrats.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Geens.Features.Contrats.Services;

namespace Geens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : ControllerBase
    {
        private readonly IServiceDadresse _service;
        private readonly ILogger<AdresseController> _logger;

        public AdresseController(ILogger<AdresseController> logger, IServiceDadresse service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUneAdresseAUnEnseignant(AdresseACreerDto adresseACreerDto)
        {
            _logger.LogInformation($"Controller :: {nameof(AjouterUneAdresseAUnEnseignant)} ");
            var result = await _service.AjouterUneAdresseAUnEnseignant(adresseACreerDto);
            return Ok(result);
        }

        [HttpPut("/detail/{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierAdresseDunEnseignant(Guid adresseId, AdresseAModifierDto adresseAModifierDto)
        {
            _logger.LogInformation($"Controller :: {nameof(ModifierAdresseDunEnseignant)} ");
            var resultat = await _service.ModifierAdresseDunEnseignant(adresseId, adresseAModifierDto);
            return Ok(resultat);
        }

        [HttpGet("/{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AdresseDetailDto>> LireAdresseDunEnseignant(Guid adresseId)
        {
            _logger.LogInformation($"Controller :: {nameof(LireAdresseDunEnseignant)} ");
            var resultat = await _service.LireAdresseUniqueDunEnseignant(adresseId);
            return Ok(resultat);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AdresseDetailDto>> LireToutesLesAdresses()
        {
            _logger.LogInformation($"Controller :: {nameof(LireToutesLesAdresses)} ");
            var resultat = await _service.LireToutesLesAdresses();
            return Ok(resultat);
        }

        [HttpGet("/enseignant/{enseignantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<AdresseDto>>> LireToutesLesAdresseDunEnseignant(Guid enseignantId)
        {
            _logger.LogInformation($"Controller :: {nameof(LireToutesLesAdresseDunEnseignant)} ");
            var resultat = await _service.LireToutesLesAdresseDunEnseignant(enseignantId);
            if (resultat.Count == 0 || resultat == null)
                return NoContent();
            return Ok(resultat);
        }

        [HttpDelete("/{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUneAdresse(Guid adresseId)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerUneAdresse)} ");
            var resultat = await _service.SupprimerAdresseDunEnseignant(adresseId);
            return Ok(resultat);
        }

        [HttpPost("/enseignant/{enseignantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ReponseDeRequette>>> AjoutterListDadresseAUnEnseignant(List<AdresseACreerDto> listAdressedto)
        {
            _logger.LogInformation($"Controller :: {nameof(AjoutterListDadresseAUnEnseignant)} ");
            var resultat = await _service.AjouterUneListeDAdresseAUnEnseignant(listAdressedto);
            return Ok(resultat);
        }
    }
}
