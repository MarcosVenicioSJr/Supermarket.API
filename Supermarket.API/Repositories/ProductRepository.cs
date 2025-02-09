using Microsoft.EntityFrameworkCore;
using Supermarket.API.Context;
using Supermarket.API.Entities;
using Supermarket.API.Interfaces;
using Supermarket.API.Interfaces.Repository;

namespace Supermarket.API.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly SupermarketContext _context;
        private readonly ICacheServices<Product> _cacheServices;


        public ProductRepository(SupermarketContext context, ICacheServices<Product> cacheServices)
        {
            _context = context;
            _cacheServices = cacheServices;
        }

        public async void Create(Product entity)
        {
            await _context.Products.AddAsync(entity);
            _context.SaveChanges();

            _cacheServices.Create(entity);
        }

        public void Delete(int id)
        {
            Product product = GetById(id).Result;

            if (product is null)
                return;

            _context.Products.Remove(product);
        }

        public async Task<Product> GetById(int id)
        {
            Product product = _cacheServices.Get().Result;

            if (product is null)
                product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is not null)
                _cacheServices.Create(product);

            return product;
        }

    }
}
