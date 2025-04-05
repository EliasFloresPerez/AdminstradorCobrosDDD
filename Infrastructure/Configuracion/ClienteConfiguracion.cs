using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades;

namespace Infrastructure.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasConversion(
                v => v.ToString(),
                v => Guid.Parse(v)
            );

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.InformacionesCobro)
                   .WithOne(ic => ic.Cliente)
                   .HasForeignKey(ic => ic.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
