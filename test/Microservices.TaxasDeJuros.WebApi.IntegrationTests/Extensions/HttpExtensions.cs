using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microservices.TaxasDeJuros.WebApi.IntegrationTests.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T> ToObjectAsync<T>(this HttpResponseMessage responseMessage)
        {
            var raw = await responseMessage.Content.ReadAsStringAsync();
            return raw.ToObject<T>();
        }

        private static T ToObject<T>(this string json) => JsonConvert.DeserializeObject<T>(json);
    }
}