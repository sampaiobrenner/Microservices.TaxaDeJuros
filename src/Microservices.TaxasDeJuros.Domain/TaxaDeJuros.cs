using Microservices.TaxasDeJuros.Domain.Base;
using System;

namespace Microservices.TaxasDeJuros.Domain
{
    public abstract class TaxaDeJuros : EntityBase
    {
        protected TaxaDeJuros(Guid id, decimal valor) : base(id) => SetValor(valor);

        public decimal Valor { get; private set; }

        private void SetValor(decimal valor)
        {
            if (default == valor)
            {
                AddError("O valor da taxa de juros deve ser maior que zero.");
                return;
            }

            Valor = valor;
        }
    }
}