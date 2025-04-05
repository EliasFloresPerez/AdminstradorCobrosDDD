using Microsoft.EntityFrameworkCore;
using Domain.Entidades;
using Infrastructure.Base;

namespace Infrastructure.Persistencia
{
    public class AplicacionDbContext : DbContext ,IDbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<InformacionCobro> InformacionCobros { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicacionDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}