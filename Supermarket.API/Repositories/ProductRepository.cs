using Supermarket.API.Context;
using Supermarket.API.Entities;
using Supermarket.API.Interfaces.Repository;

namespace Supermarket.API.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly SupermarketContext _context;

        public ProductRepository(SupermarketContext context)
        {
            this._context = context;
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
