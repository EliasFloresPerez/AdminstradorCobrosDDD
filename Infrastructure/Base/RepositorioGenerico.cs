using Microsoft.EntityFrameworkCore;
using Domain.Abstracto;

namespace Infrastructure.Base
{

    public abstract class RepositorioGenerico <T> : IRepositorio<T> where T : class, IEntity
    {
        protected readonly IDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositorioGenerico(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T Agregar(T entidad)
        {
            _dbSet.Add(entidad);
            
            return entidad;
        }

        public void Actualizar(T entidad)
        {
            _context.SetModified(entidad);
        }

        public void Eliminar(T entidad)
        {
            _dbSet.Remove(entidad);
        }

        public T? ObtenerPorId(Guid id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T?> ObtenerPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
    
}