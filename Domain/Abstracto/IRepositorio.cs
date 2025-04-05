namespace Domain.Abstracto
{
    public interface IRepositorio<T> where T : IEntity
    {
        T?   ObtenerPorId(Guid id);
        T Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T entidad);

        Task<T?> ObtenerPorIdAsync(Guid id);
    }
}