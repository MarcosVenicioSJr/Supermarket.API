namespace Supermarket.API.Interfaces.Services
{
    public interface IServices<T> where T : class
    {
        T GetById(int id);
    }
}
