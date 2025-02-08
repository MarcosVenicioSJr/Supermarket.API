using Supermarket.API.Entities;
using Supermarket.API.Entities.Request;

namespace Supermarket.API.Mapper
{
    public static class ProductMapper
    {
        public static Product MapperCreateProductToProduct(CreateProduct model)
        {
            return new Product
            {
                Name = model.Name,
                Category = model.Category,
                Quantity = model.Quantity,
                Value = model.Value
            };
        }
    }
}
