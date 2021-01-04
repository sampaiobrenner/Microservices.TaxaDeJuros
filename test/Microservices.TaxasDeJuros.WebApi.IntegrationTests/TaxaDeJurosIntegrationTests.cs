using System.Threading.Tasks;
using Microservices.TaxasDeJuros.WebApi.IntegrationTests.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Microservices.TaxasDeJuros.WebApi.IntegrationTests
{
    public class TaxaDeJurosIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TaxaDeJurosIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_DadoEndpointDeTaxaDeJurosPadrao_RetornaTaxaDeJurosPadrao()
        {
            // Arrange
            var client = _factory.CreateClient();
            var taxaDeJurosPadrao = 1.00m;

            // Act
            var response = await client.GetAsync("/api/v2/taxaJurosPadrao");
            var resultAsString = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal(taxaDeJurosPadrao, resultAsString.ParseDecimal(), 2);
        }

        [Fact]
        public async Task Get_DadoEndpointDeTaxaDeJurosReduzida_RetornaTaxaDeJurosReduzida()
        {
            // Arrange
            var client = _factory.CreateClient();
            var taxaDeJurosReduzida = 0.01m;

            // Act
            var response = await client.GetAsync("/api/v1/taxaJuros");
            var resultAsString = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal(taxaDeJurosReduzida, resultAsString.ParseDecimal(), 2);
        }
    }
}