using Microservices.TaxasDeJuros.Entities.Entities;

namespace Microservices.TaxasDeJuros.Entities.Builders
{
    public sealed class TaxaDeJurosReduzidaBuilder : TaxaDeJurosBuilder<TaxaDeJurosReduzidaBuilder, TaxaDeJurosReduzida>
    {
        public override TaxaDeJurosReduzida Build() => TaxaDeJurosReduzida.CreateInstance(Id, Valor);
    }
}