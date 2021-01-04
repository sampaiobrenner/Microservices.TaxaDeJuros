﻿using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Microservices.TaxasDeJuros.Domain;
using Microservices.TaxasDeJuros.Repositories.Abstractions;
using Microservices.TaxasDeJuros.Services.Abstractions;
using Moq;
using Xunit;
using FluentAssertions;

namespace Microservices.TaxasDeJuros.Services.Tests
{
    public class TaxaDeJurosServiceTest
    {
        private readonly Mock<ITaxaDeJurosRepository> _taxaDeJurosRepository;
        private readonly ITaxaDeJurosService _taxaDeJurosService;
        private readonly Faker _faker;
        private readonly CancellationToken _cancellationToken;
        
        public TaxaDeJurosServiceTest()
        {
            _taxaDeJurosRepository = new Mock<ITaxaDeJurosRepository>();
            _taxaDeJurosService = new TaxaDeJurosService(_taxaDeJurosRepository.Object);
            _faker = new Faker();
            _cancellationToken = CancellationToken.None;
        }
        
        [Fact]
        public async Task Deve_Obter_Taxa_De_Juros_Reduzida_Com_Sucesso() 
        {
            var taxaDeJurosReduzidaEsperada = _faker.Random.Int(0);
            _taxaDeJurosRepository.Setup(x => x.GetValorAsync<TaxaDeJurosReduzida>(It.IsAny<CancellationToken>())).ReturnsAsync(taxaDeJurosReduzidaEsperada);

            var taxaDeJurosReduzida = await _taxaDeJurosService.GetTaxaDeJurosReduzidaAsync(_cancellationToken);
            
            _taxaDeJurosRepository.Verify(x => x.GetValorAsync<TaxaDeJurosReduzida>(_cancellationToken));
            taxaDeJurosReduzida.Should().Be(taxaDeJurosReduzidaEsperada);
        }
    }
}