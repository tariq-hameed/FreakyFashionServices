using FreakyFashionServices.Basket.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FreakyFashionServices.Basket.Extensions;

namespace FreakyFashionServices.Basket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        //List<string> todos = new List<string>(); 
        private readonly IDistributedCache cache;
        public BasketController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        [HttpGet("{id}")]
        public async Task<BasketDto> GetBasket(String id)
        {
            var serializedData = await cache.GetStringAsync(id);
            var basket = JsonSerializer.Deserialize<BasketDto>(serializedData);
            
            return basket; //200 ok
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateBasket(BasketDto createBasketDto)
        {
            await cache.SetRecordAsync(createBasketDto.Id.ToString(), createBasketDto);
            return Ok(); //200 ok
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasket(int id, [FromBody] BasketDto basket) 
        {
            await cache.SetRecordAsync(id.ToString(), basket);
            return Ok();
        }


        
    }
}
