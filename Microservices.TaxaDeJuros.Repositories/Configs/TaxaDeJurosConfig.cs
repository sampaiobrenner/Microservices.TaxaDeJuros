using Microservices.TaxasDeJuros.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservices.TaxasDeJuros.Repositories.Configs
{
    public class TaxaDeJurosEntityConfig : IEntityTypeConfiguration<TaxaDeJuros>
    {
        public void Configure(EntityTypeBuilder<TaxaDeJuros> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasDiscriminator()
                .HasValue<TaxaDeJurosPadrao>(nameof(TaxaDeJurosPadrao))
                .HasValue<TaxaDeJurosReduzida>(nameof(TaxaDeJurosReduzida));

            builder.HasIndex("Discriminator").IsUnique();
        }
    }
}