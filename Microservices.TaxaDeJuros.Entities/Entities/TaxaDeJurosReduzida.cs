using System;

namespace Microservices.TaxaDeJuros.Entities.Entities
{
    public sealed class TaxaDeJurosReduzida : TaxaDeJuros
    {
        private TaxaDeJurosReduzida(Guid id, decimal valor) : base(id, valor)
        {
        }

        internal static TaxaDeJurosReduzida CreateInstance(Guid id, decimal valor) => new TaxaDeJurosReduzida(id, valor);
    }
}