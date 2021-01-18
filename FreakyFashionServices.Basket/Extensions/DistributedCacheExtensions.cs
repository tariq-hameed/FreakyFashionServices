using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static object JsonSearlizer { get; private set; }

        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordId, 
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpiredTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedExpiredTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);
            if(jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
               
        }
    }
}
