using System;
using Xunit;

namespace Microservices.TaxasDeJuros.Domain.UnitTests
{
    public class TaxaDeJurosPadraoUnitTests
    {
        [Fact]
        public void DadoInformacoesInvalidaDaTaxaDeJurosReduzida_CriarEValidarTaxaDeJuros()
        {
            var taxaDeJuros = new TaxaDeJurosPadraoBuilder()
                .WithId(Guid.NewGuid())
                .WithValor(0)
                .Build();

            Assert.False(taxaDeJuros.IsValid);
        }

        [Theory]
        [InlineData(2.5)]
        [InlineData(12)]
        public void DadoInformacoesValidaDaTaxaDeJurosReduzida_CriarEValidarTaxaDeJuros(decimal valor)
        {
            var id = Guid.NewGuid();

            var taxaDeJuros = new TaxaDeJurosPadraoBuilder()
                .WithId(id)
                .WithValor(valor)
                .Build();

            Assert.Equal(id, taxaDeJuros.Id);
            Assert.Equal(valor, taxaDeJuros.Valor);
            Assert.True(taxaDeJuros.IsValid);
        }
    }
}