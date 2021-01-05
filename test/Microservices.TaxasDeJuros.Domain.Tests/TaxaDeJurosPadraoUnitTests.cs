using Bogus;
using FluentAssertions;
using Xunit;

namespace Microservices.TaxasDeJuros.Domain.UnitTests
{
    public class TaxaDeJurosPadraoUnitTests
    {
        private readonly Faker _faker;
        public TaxaDeJurosPadraoUnitTests()
        {
            _faker = new Faker();
        }
        
        [Theory]
        [InlineData(-2.5)]
        [InlineData(0)]
        public void Deve_Retornar_Erro_Ao_Construir_Taxa_De_Juros_Padrao_Com_Valor_Invalido(decimal valor)
        {
            var id = _faker.Random.Guid();
            
            var taxaDeJuros = new TaxaDeJurosPadraoBuilder()
                .WithId(id)
                .WithValor(valor)
                .Build();
            
            taxaDeJuros.Id.Should().Be(id);
            taxaDeJuros.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(2.5)]
        [InlineData(12)]
        public void DadoInformacoesValidaDaTaxaDeJurosReduzida_CriarEValidarTaxaDeJuros(decimal valor)
        {
            var id = _faker.Random.Guid();

            var taxaDeJuros = new TaxaDeJurosPadraoBuilder()
                .WithId(id)
                .WithValor(valor)
                .Build();

            taxaDeJuros.Id.Should().Be(id);
            taxaDeJuros.Valor.Should().Be(valor);
            taxaDeJuros.IsValid.Should().BeTrue();
        }
    }
}