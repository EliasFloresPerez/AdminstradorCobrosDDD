namespace Domain.Abstracto
{
    
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        //Asincronico
        Task<int> CommitAsync();
    }
}