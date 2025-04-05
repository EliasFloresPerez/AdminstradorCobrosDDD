using Domain.Abstracto;
using Domain.Entidades;



namespace Domain.Repositorios
{
    public interface IRepositorioInfCobro : IRepositorio<InformacionCobro>
    {

        //Buscar un cobro por su Id
        Task<IEnumerable<InformacionCobro>> ObtenerPorClienteIdAsync(Guid clienteId);

    }
}