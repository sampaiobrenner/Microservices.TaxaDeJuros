namespace Microservices.TaxasDeJuros.Domain.Abstractions
{
    public abstract class TaxaDeJurosBuilder<TBuilder, TEntity> : BuilderBase<TBuilder, TEntity>
        where TBuilder : TaxaDeJurosBuilder<TBuilder, TEntity>
        where TEntity : class
    {
        public decimal Valor { get; private set; }

        public TBuilder WithValor(decimal valor)
        {
            Valor = valor;
            return (TBuilder)this;
        }
    }
}