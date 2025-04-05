using Microsoft.EntityFrameworkCore;
using Domain.Abstracto;

namespace Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext? _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            
            if (_context == null)
                throw new InvalidOperationException("El contexto no puede ser nulo al momento de hacer commit.");

            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            if (_context == null)
                throw new InvalidOperationException("El contexto no puede ser nulo al momento de hacer commit.");

            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                
                (_context as DbContext)?.Dispose();
                _context = null;
            }
        }
    }
}
