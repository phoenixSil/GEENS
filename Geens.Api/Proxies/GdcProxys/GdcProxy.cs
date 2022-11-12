using AutoMapper;
using Geens.Api.Dtos;
using Geens.Api.Dtos.Enseignants;
using Geens.Api.Modeles;
using Geens.Api.Proxies.GdcProxys.Contrats;
using Geens.Api.Services.Contrats;
using MsCommun.Reponses;

namespace Geens.Api.Proxies.GdcProxys
{
    public class GdcProxy: IGdcProxy
    {
        private readonly HttpClient _httpClient;
		public readonly IMapper _mapper;
		
        public GdcProxy(IMapper mapper, HttpClient httpClient)
        {
            _httpClient = httpClient;
			_mapper = mapper;
        }

        public async Task<ReponseDeRequette> AjouterUnEnseignant(Enseignant enseignant)
        {
            var dto = GenerateDtoEnseignantPourGdc(enseignant);
            var enseignantStringContent = UtilProxy.SerializeRequette(dto);
            var response = await _httpClient.PostAsync($"Cours/Enseignant", enseignantStringContent).ConfigureAwait(false);

            UtilProxy.VerifierSiLappelAEchouer(response);

            var parsed = await UtilProxy.DeserializeHttpResponse<ReponseDeRequette>(response);

            if (parsed.Success)
                return parsed;
            throw new Exception($" parsed na pas marcher {parsed}");
        }

        private EnseignantGdcACreerDto GenerateDtoEnseignantPourGdc(Enseignant enseignant)
        {
            var enseignantgdcDto = _mapper.Map<EnseignantGdcACreerDto>(enseignant);
            return enseignantgdcDto;
        }
    }
}

