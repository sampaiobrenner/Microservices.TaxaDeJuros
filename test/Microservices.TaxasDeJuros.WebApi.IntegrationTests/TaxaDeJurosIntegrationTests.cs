using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microservices.TaxasDeJuros.WebApi.IntegrationTests.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Microservices.TaxasDeJuros.WebApi.IntegrationTests
{
    public class TaxaDeJurosIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        
        public TaxaDeJurosIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Deve_Retornar_Taxa_De_Juros_Padrao_Com_Sucesso()
        {
            const decimal taxaDeJurosPadraoEsperada = 1.00m;

            var response = await _httpClient.GetAsync("/api/v2/taxaJurosPadrao");
            var taxaDeJurosPadrao = await response.ToObjectAsync<decimal>();
            
            taxaDeJurosPadrao.Should().Be(taxaDeJurosPadraoEsperada);
        }

        [Fact]
        public async Task Deve_Retornar_Taxa_De_Juros_Reduzida_Com_Sucesso()
        {
            const decimal taxaDeJurosReduzidaEsperada = 0.01m;

            var response = await _httpClient.GetAsync("/api/v1/taxaJuros");
            var taxaDeJurosReduzida = await response.ToObjectAsync<decimal>();
            
            taxaDeJurosReduzida.Should().Be(taxaDeJurosReduzidaEsperada);
        }
    }
}