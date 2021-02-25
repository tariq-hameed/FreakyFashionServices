using FreakyFashionServices.Basket.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public GatewayController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        [HttpGet("{articleNumber}")]
        public async Task<ItemsDto> GetPrices(string articleNumber)
        {
            // Hämta items-information för Article-Number (t.ex. /api/items/ABC123)
            var request = new HttpRequestMessage(HttpMethod.Get, "http://freakyfashionservices.catalog/api/items/" + articleNumber);
            request.Headers.Add("Accept", "application/json");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var serializedItems = await response.Content.ReadAsStringAsync();

            //var serializeOptions = new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //};
            var itemsDto = JsonConvert.DeserializeObject<ItemsDto>(serializedItems);
            // Hämta price-information för Article-Number (t.ex. /productprice/ABC123)
            request = new HttpRequestMessage(HttpMethod.Get, "http://freakyfashionservices.productprice/productprice/" + articleNumber);
            request.Headers.Add("Accept", "application/json");
            response = await client.SendAsync(request);
            var serializedPrice = await response.Content.ReadAsStringAsync();
            var priceDto = JsonConvert.DeserializeObject<PricesDto>(serializedPrice);
            itemsDto.Price = priceDto;

            return itemsDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasket(BasketDto basket, string id)
        {
            var serializedBasket = JsonConvert.SerializeObject(basket);
            var request = new HttpRequestMessage(HttpMethod.Put, "http://freakyfashionservices.basket/basket/" + id);
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent(serializedBasket, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);



            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return BadRequest();
        }


        [HttpPost("Order")]
        public async Task<ActionResult> PostOrder(OrdersDto ordersDto)
        {
            var serializedOrder = JsonConvert.SerializeObject(ordersDto);
            var request = new HttpRequestMessage(HttpMethod.Post, "http://freakyfashionservices.order/order");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent(serializedOrder, Encoding.UTF8, "application/json");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }
            var myContent = await response.Content.ReadAsStringAsync();
            var myDto = JsonConvert.DeserializeObject(myContent);
            return Ok(myDto);
        }

        public class OrdersDto
        {
            
            public string CustomerIdentifier { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }

        public class BasketDto
        {
            public string Id { get; set; }
            public IList<ProductDto> Products { get; set; }
        }
        public class ProductDto
        {
            public string Id { get; set; }
            public string ProductName { get; set; }
            public int UnitPrice { get; set; }
            public int Quantity { get; set; }

        }


        public class ItemsDto
        {
            //public int Id { get; set; }
            public string ArticleNumber { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public PricesDto Price { get; set; }
            public int AvailableStock { get; set; }
        }
        public class PricesDto
        {
            //public int Id { get; set; }
            //public string ArticleNumber { get; set; }
            public string Price { get; set; }
        }

        
    }
}
