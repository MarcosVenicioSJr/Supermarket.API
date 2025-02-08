using Supermarket.API.Entities;
using Supermarket.API.Interfaces.Repository;
using Supermarket.API.Interfaces.Services;

namespace Supermarket.API.Services
{
    public class ProductServices : IServices<Product>
    {
        private readonly IRepository<Product> _repository;
        public ProductServices(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
