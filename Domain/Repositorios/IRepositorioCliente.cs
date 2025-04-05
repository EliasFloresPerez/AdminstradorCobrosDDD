
using Domain.Abstracto;
using Domain.Entidades;


namespace Domain.Repositorios
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task<Cliente> ObtenerPorNombreAsync(string nombre);
    }
}