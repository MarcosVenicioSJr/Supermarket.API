using Supermarket.API.Entities;
using Supermarket.API.Entities.Enums;

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

        public void Create(Product entity)
        {
            entity.BarCode = GenerateBarCode();
            entity.ProductStatus = ProductStatus.Active;

            _repository.Create(entity);
        }

        public Product GetById(int id) 
            => _repository.GetById(id).Result;


        private string GenerateBarCode()
        {
            Random random = new Random();

            string baseCode = string.Concat(Enumerable.Range(0, 12).Select(_ => random.Next(0, 10)));

            int sum = 0;

            for (int i = 0; i < 12; i++)
            {
                int digit = baseCode[i] - '0';
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            int verifyDigit = (10 - (sum % 10)) % 10;

            return baseCode + verifyDigit;
        }
    }
}
