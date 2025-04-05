using Microsoft.EntityFrameworkCore;
using Domain.Entidades;
using Infrastructure.Base;

namespace Infrastructure.Persistencia
{
    public class AplicacionDbContext : DbContext ,IDbContext
    {
        public AplicacionDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicacionDbContext).Assembly);
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<InformacionCobro> InformacionCobros { get; set; }

        

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}