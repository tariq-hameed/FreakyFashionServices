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
        public async Task<CreateBasketDto> GetBasket(String id)
        {
            var serializedData = await cache.GetStringAsync(id);
            var basket = JsonSerializer.Deserialize<CreateBasketDto>(serializedData);
            
            return basket; //200 ok
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            await cache.SetRecordAsync(createBasketDto.Id, createBasketDto);           
            return Ok(); //200 ok
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbas(int id, [FromBody] CreateBasketDto basket)
        {
            await cache.SetRecordAsync<CreateBasketDto>(id.ToString(), basket);
            return Ok();
        }


        
    }
}
