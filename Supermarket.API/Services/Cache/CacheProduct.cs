using Microsoft.Extensions.Caching.Distributed;
using Supermarket.API.Entities;
using Newtonsoft.Json;
using System.Text;
using Supermarket.API.Interfaces;

namespace Supermarket.API.Services.Cache
{
    public class CacheProduct : ICacheServices<Product>
    {
        private readonly IDistributedCache _distributedCache;
        public CacheProduct(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async void Create(Product product)
        {
            var cacheKey = "product_";

            var serializerObject = JsonConvert.SerializeObject(product);
            var redisObject = Encoding.UTF8.GetBytes(serializerObject);

            var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

            await _distributedCache.SetAsync(cacheKey.ToString(), redisObject, options);
        }

        public async Task<Product> Get()
        {
            var cacheKey = "product_";

            var redisObject = await _distributedCache.GetAsync(cacheKey.ToString());

            if(redisObject is not null)
            {
                var serializerProduct = Encoding.UTF8.GetString(redisObject);
                var entity = JsonConvert.DeserializeObject<Product>(serializerProduct);
                return entity;
            }

            return null;
        }
    }
}
