using Microsoft.EntityFrameworkCore;
using Supermarket.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.API.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(18, 2)]
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductCategory Category { get; set; }
    }
}
