using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> GetById(int id) =>
            await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
}
