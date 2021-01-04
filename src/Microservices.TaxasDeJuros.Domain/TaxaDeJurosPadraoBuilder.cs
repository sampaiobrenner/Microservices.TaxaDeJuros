namespace Microservices.TaxasDeJuros.Domain.Builders
{
    public sealed class TaxaDeJurosPadraoBuilder : TaxaDeJurosBuilder<TaxaDeJurosPadraoBuilder, TaxaDeJurosPadrao>
    {
        public override TaxaDeJurosPadrao Build() => TaxaDeJurosPadrao.CreateInstance(Id, Valor);
    }
}