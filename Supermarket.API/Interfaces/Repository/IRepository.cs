namespace Supermarket.API.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        void Create(T entity);
    }
}
