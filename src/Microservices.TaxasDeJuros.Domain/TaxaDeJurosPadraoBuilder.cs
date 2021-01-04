using Microservices.TaxasDeJuros.Domain.Abstractions;

namespace Microservices.TaxasDeJuros.Domain
{
    public sealed class TaxaDeJurosPadraoBuilder : TaxaDeJurosBuilder<TaxaDeJurosPadraoBuilder, TaxaDeJurosPadrao>
    {
        public override TaxaDeJurosPadrao Build() => TaxaDeJurosPadrao.CreateInstance(Id, Valor);
    }
}