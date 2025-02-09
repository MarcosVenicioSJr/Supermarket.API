namespace Supermarket.API.Interfaces
{
    public interface ICacheServices <T> where T : class
    {
        void Create(T entity);

        Task<T> Get();
    }
}
