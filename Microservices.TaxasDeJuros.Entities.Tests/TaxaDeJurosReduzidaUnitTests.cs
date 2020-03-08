using Microservices.TaxasDeJuros.Entities.Builders;
using System;
using Xunit;

namespace Microservices.TaxasDeJuros.Entities.UnitTests
{
    public class TaxaDeJurosReduzidaUnitTests
    {
        [Fact]
        public void CriarTaxaDeJurosReduzidaInvalida()
        {
            var taxaDeJuros = new TaxaDeJurosReduzidaBuilder()
                .WithId(Guid.NewGuid())
                .WithValor(0)
                .Build();

            Assert.False(taxaDeJuros.IsValid);
        }

        [Theory]
        [InlineData(2.5)]
        [InlineData(12)]
        public void CriarTaxaDeJurosReduzidaValida(decimal valor)
        {
            var id = Guid.NewGuid();

            var taxaDeJuros = new TaxaDeJurosReduzidaBuilder()
                .WithId(id)
                .WithValor(valor)
                .Build();

            Assert.Equal(id, taxaDeJuros.Id);
            Assert.Equal(valor, taxaDeJuros.Valor);
            Assert.True(taxaDeJuros.IsValid);
        }
    }
}