using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entidades;

namespace Infrastructure.Configuration
{
    public class InformacionCobroConfiguration : IEntityTypeConfiguration<InformacionCobro>
    {
        public void Configure(EntityTypeBuilder<InformacionCobro> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasConversion(
                v => v.ToString(),
                v => Guid.Parse(v)
            );

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.ClienteId)
                .IsRequired();

            builder.HasOne(ic => ic.Cliente)
                   .WithMany(c => c.InformacionesCobro)
                   .HasForeignKey(ic => ic.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
