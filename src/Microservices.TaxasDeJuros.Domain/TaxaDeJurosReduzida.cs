using System;
using Microservices.TaxasDeJuros.Domain.Abstractions;

namespace Microservices.TaxasDeJuros.Domain
{
    public sealed class TaxaDeJurosReduzida : TaxaDeJuros
    {
        private TaxaDeJurosReduzida(Guid id, decimal valor) : base(id, valor)
        {
        }

        internal static TaxaDeJurosReduzida CreateInstance(Guid id, decimal valor) => new TaxaDeJurosReduzida(id, valor);
    }
}