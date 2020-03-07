using Microservices.TaxaDeJuros.Entities.Entities;

namespace Microservices.TaxaDeJuros.Entities.Builders
{
    public sealed class TaxaDeJurosReduzidaBuilder : TaxaDeJurosBuilder<TaxaDeJurosReduzidaBuilder, TaxaDeJurosReduzida>
    {
        public override TaxaDeJurosReduzida Build() => TaxaDeJurosReduzida.CreateInstance(Id, Valor);
    }
}