
using Application.Base;
using Application.Dtos;



namespace Application.Abstracto
{
    public interface IServicioGenerico<T> : IService where T : class
    {
        Task<CResponse> AgregarAsync(T entity);
        Task<CResponse> EliminarAsync(Guid id);
        Task<CResponse> ObtenerPorIdAsync(Guid id);
        Task<List<T>> ObtenerTodosAsync();
    }
}