using Geens.Features.Dtos;
using Geens.Domain.Modeles;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Geens.Features.Proxies
{
    public static class UtilProxy
    {
        public static StringContent SerializeRequette(object dto)
        {
            return new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json");
        }

        public static void VerifierSiLappelAEchouer(HttpResponseMessage response)
        {
           if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new InvalidOperationException("La Route na pas ete trouver ");
           if(response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Internal Server Exception Error ");
            }
        }

        public static async Task<T> DeserializeHttpResponse<T>(HttpResponseMessage resultCall)
        {
            var stream = await resultCall.Content.ReadAsStreamAsync();
            T t = await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return t;
        }
    }
}
