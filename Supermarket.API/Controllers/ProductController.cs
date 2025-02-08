using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Entities;
using Supermarket.API.Entities.Request;
using Supermarket.API.Interfaces.Services;
using Supermarket.API.Mapper;

namespace Supermarket.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServices<Product> _services;

        public ProductController(IServices<Product> services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product entity = _services.GetById(id);

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] CreateProduct model)
        {
            Product entity = ProductMapper.MapperCreateProductToProduct(model);
            _services.Create(entity);
            return Created();
        }
    }
}
