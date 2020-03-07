﻿using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Services.Services
{
    public interface ITaxaDeJurosServices
    {
        Task<decimal> GetTaxaDeJurosPadrao();
    }
}