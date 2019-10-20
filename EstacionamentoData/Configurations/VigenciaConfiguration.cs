using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionamentoDomain.Entities;

namespace EstacionamentoData.Configurations
{
    public class VigenciaConfiguration : IEntityTypeConfiguration<Vigencia>
    {
        public virtual void Configure(EntityTypeBuilder<Vigencia> builder)
        {
            builder.HasIndex(index => index.Id)
                .IsUnique();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ValorHora).IsRequired();
            builder.Property(p => p.VigenciaFim).IsRequired();
            builder.Property(p => p.VigenciaInicio).IsRequired();
            builder.Property(p => p.Ativo).HasDefaultValue(true);
        }
    }
}