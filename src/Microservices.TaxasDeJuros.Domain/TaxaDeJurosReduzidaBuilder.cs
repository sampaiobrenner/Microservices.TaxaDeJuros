namespace Microservices.TaxasDeJuros.Domain.Builders
{
    public sealed class TaxaDeJurosReduzidaBuilder : TaxaDeJurosBuilder<TaxaDeJurosReduzidaBuilder, TaxaDeJurosReduzida>
    {
        public override TaxaDeJurosReduzida Build() => TaxaDeJurosReduzida.CreateInstance(Id, Valor);
    }
}