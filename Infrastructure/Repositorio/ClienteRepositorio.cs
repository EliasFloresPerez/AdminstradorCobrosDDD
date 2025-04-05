using Domain.Entidades;
using Infrastructure.Base;
using Domain.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorio
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente>, IRepositorioCliente
    {
        private readonly IDbContext _dbContext;

        public ClienteRepositorio(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
        {
            return await _dbContext.Set<Cliente>().ToListAsync();
        }

        public async Task<Cliente> ObtenerPorNombreAsync(string nombre)
        {
            return await _dbContext.Set<Cliente>().FirstAsync(c => c.Nombre == nombre);
        }
    
    
        

    }
}