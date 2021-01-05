using System;

namespace Microservices.TaxasDeJuros.Domain.Abstractions
{
    public abstract class TaxaDeJuros : EntityBase
    {
        protected TaxaDeJuros(Guid id, decimal valor) : base(id) => SetValor(valor);

        public decimal Valor { get; private set; }

        private void SetValor(decimal valor)
        {
            if (valor <= 0)
            {
                AddError("O valor da taxa de juros deve ser maior que zero.");
                return;
            }

            Valor = valor;
        }
    }
}