﻿using System;

namespace Microservices.TaxaDeJuros.Entities.Entities
{
    public sealed class TaxaDeJurosPadrao : TaxaDeJuros
    {
        private TaxaDeJurosPadrao(Guid id, decimal valor) : base(id, valor)
        {
        }

        internal static TaxaDeJurosPadrao CreateInstance(Guid id, decimal valor) => new TaxaDeJurosPadrao(id, valor);
    }
}