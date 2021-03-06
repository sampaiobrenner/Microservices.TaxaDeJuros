﻿using Microservices.TaxasDeJuros.Domain;
using Microservices.TaxasDeJuros.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.TaxasDeJuros.Domain.Abstractions;
using Microservices.TaxasDeJuros.Repositories.Abstractions;

namespace Microservices.TaxasDeJuros.Repositories.Seeds
{
    public class Seed : ISeed
    {
        private readonly TaxaDeJurosDbContext _context;

        public Seed(TaxaDeJurosDbContext context) => _context = context;

        public void Execute() => ExecuteAsync().Wait();

        private async Task ExecuteAsync()
        {
            if (!_context.TaxasDeJuros.Any()) await GerarTaxasDeJurosAsync();

            await _context.SaveChangesAsync();
        }

        private async Task GerarTaxasDeJurosAsync()
        {
            var taxaDeJurosReduzida = new TaxaDeJurosReduzidaBuilder()
                .WithId(Guid.NewGuid())
                .WithValor(0.01m)
                .Build();

            var taxaDeJurosPadrao = new TaxaDeJurosPadraoBuilder()
                .WithId(Guid.NewGuid())
                .WithValor(1)
                .Build();

            var taxasDeJuros = new List<TaxaDeJuros> { taxaDeJurosReduzida, taxaDeJurosPadrao };

            await _context.TaxasDeJuros.AddRangeAsync(taxasDeJuros);
        }
    }
}