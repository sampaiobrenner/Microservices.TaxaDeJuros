﻿using Microservices.TaxasDeJuros.Domain;
using Microsoft.EntityFrameworkCore;

namespace Microservices.TaxasDeJuros.Repositories.Context
{
    public class TaxaDeJurosDbContext : DbContext, ITaxaDeJurosDbContext
    {
        public TaxaDeJurosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaxaDeJuros> TaxasDeJuros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxaDeJurosDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}