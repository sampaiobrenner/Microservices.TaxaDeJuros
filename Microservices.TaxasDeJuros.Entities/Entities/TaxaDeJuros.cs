using Microservices.TaxasDeJuros.Entities.Base;
using System;

namespace Microservices.TaxasDeJuros.Entities.Entities
{
    public class TaxaDeJuros : EntityBase
    {
        public TaxaDeJuros(Guid id, decimal valor) : base(id) => SetValor(valor);

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