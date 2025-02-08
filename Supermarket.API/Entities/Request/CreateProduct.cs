using Supermarket.API.Entities.Enums;

namespace Supermarket.API.Entities.Request
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; }
    }
}
