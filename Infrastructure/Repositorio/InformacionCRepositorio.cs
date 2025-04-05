using Domain.Entidades;
using Infrastructure.Base;
using Domain.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorio
{
    public class InformacionCRepositorio : RepositorioGenerico<InformacionCobro>, IRepositorioInfCobro
    {
        private readonly IDbContext _dbContext;

        public InformacionCRepositorio(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //ObtenerPorClienteIdAsync
        public async Task<IEnumerable<InformacionCobro>> ObtenerPorClienteIdAsync(Guid clienteId)
        {
            return await _dbContext.Set<InformacionCobro>()
                .Where(c => c.ClienteId == clienteId && c.Estado == true)
                .ToListAsync();
        }
    }
}