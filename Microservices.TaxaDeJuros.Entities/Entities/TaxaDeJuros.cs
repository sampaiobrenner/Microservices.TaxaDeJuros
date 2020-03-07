using Microservices.TaxasDeJuros.Entities.Base;
using System;

namespace Microservices.TaxasDeJuros.Entities.Entities
{
    public abstract class TaxaDeJuros : EntityBase
    {
        protected TaxaDeJuros(Guid id, decimal valor) : base(id)
        {
            SetValor(valor);
        }

        public decimal Valor { get; private set; }

        private void SetValor(decimal valor) => Valor = valor;
    }
}