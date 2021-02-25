using FreakyFashionServices.Order.Data;
using FreakyFashionServices.Order.Model.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly FreakyFashionOrderContext _context;
        private readonly IHttpClientFactory clientFactory;

        public OrderController(FreakyFashionOrderContext context, IHttpClientFactory clientFactory) 
        {
            _context = context;
            this.clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostItems(Orders orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();
            return Ok();

            //return CreatedAtAction("GetById", new { id = orders.Id }, orders);
        }
        //[HttpPost]
        //public async Task<ActionResult> PostItems(string id, [FromBody] Orders orders)
        //{

        //    var request = new HttpRequestMessage(HttpMethod.Get, "http://freakyfashionservices.basket/basket/" + id);
        //    request.Headers.Add("Accept", "application/json");
        //    var client = clientFactory.CreateClient();
        //    var response = await client.SendAsync(request);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return NotFound();
        //    }

        //    var serializedItems = await response.Content.ReadAsStringAsync();

        //    var basketDto = JsonConvert.DeserializeObject<BasketDto>(serializedItems);

        //    _context.Orders.Where(x => x.CustomerIdentifier == basketDto.Id).FirstOrDefault<Orders>();

        //    _context.Orders.Add(orders);
        //    await _context.SaveChangesAsync();

        //    return Ok(basketDto);

        //}

        public class BasketDto
        {
            public string Id { get; set; }           

        }
    }
}
