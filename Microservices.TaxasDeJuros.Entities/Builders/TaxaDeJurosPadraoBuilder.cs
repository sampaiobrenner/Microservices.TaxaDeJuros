using Microservices.TaxasDeJuros.Entities.Entities;

namespace Microservices.TaxasDeJuros.Entities.Builders
{
    public sealed class TaxaDeJurosPadraoBuilder : TaxaDeJurosBuilder<TaxaDeJurosPadraoBuilder, TaxaDeJurosPadrao>
    {
        public override TaxaDeJurosPadrao Build() => TaxaDeJurosPadrao.CreateInstance(Id, Valor);
    }
}