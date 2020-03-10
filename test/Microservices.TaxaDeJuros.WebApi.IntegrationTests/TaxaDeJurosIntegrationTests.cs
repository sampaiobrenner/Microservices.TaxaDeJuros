using Microservices.TaxasDeJuros.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.TaxaDeJuros.WebApi.IntegrationTests
{
    public class TaxaDeJurosIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TaxaDeJurosIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/v1/taxaJuros")]
        [InlineData("/api/v2/taxaJurosPadrao")]
        public async Task Get_ValidarRetornoDaTaxaDeJuros(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}