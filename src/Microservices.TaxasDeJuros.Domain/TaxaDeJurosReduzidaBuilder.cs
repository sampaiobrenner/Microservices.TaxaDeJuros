using Microservices.TaxasDeJuros.Domain.Abstractions;

namespace Microservices.TaxasDeJuros.Domain
{
    public sealed class TaxaDeJurosReduzidaBuilder : TaxaDeJurosBuilder<TaxaDeJurosReduzidaBuilder, TaxaDeJurosReduzida>
    {
        public override TaxaDeJurosReduzida Build() => TaxaDeJurosReduzida.CreateInstance(Id, Valor);
    }
}