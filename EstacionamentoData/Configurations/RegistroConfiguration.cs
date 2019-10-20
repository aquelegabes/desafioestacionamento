using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EstacionamentoDomain.Entities;

namespace EstacionamentoData.Configurations
{
    public class RegistroConfiguration : IEntityTypeConfiguration<Registro>
    {
        public virtual void Configure(EntityTypeBuilder<Registro> builder)
        {
            builder.HasIndex(index => index.Id)
                .IsUnique();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Placa).IsRequired();
            builder.Property(p => p.Preco);
            builder.Property(p => p.ValorTotal);
            builder.Property(p => p.Chegada);
            builder.Property(p => p.Duracao);
            builder.Property(p => p.Saida);
            builder.Property(p => p.TempoCobrado);
            builder.Property(p => p.Ativo).HasDefaultValue(true);
        }
    }
}