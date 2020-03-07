using Microservices.TaxaDeJuros.Entities.Entities;

namespace Microservices.TaxaDeJuros.Entities.Builders
{
    public sealed class TaxaDeJurosPadraoBuilder : TaxaDeJurosBuilder<TaxaDeJurosPadraoBuilder, TaxaDeJurosPadrao>
    {
        public override TaxaDeJurosPadrao Build() => TaxaDeJurosPadrao.CreateInstance(Id, Valor);
    }
}