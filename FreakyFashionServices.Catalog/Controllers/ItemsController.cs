using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashionServices.Catalog.Models;
using FreakyFashionServices.Catalog.Models.Data;
using FreakyFashionServices.Catalog.Models.DTO;

namespace FreakyFashionServices.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly FreakyFashionContext _context;
        public ItemsController(FreakyFashionContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<ItemsDto> GetAll()
        {
            var myItems = _context.Items.ToList();
            var projectedItems = myItems.Select(x => new ItemsDto
            {
                Id = x.Id,
                ArticleNumber = x.ArticleNumber,
                Name = x.Name,
                Description = x.Description,
                AvailableStock = x.AvailableStock
            });
            return projectedItems;
        }
        

        //[HttpGet("{id}")]
        //public ActionResult<ItemsDto> GetById(int id)
        //{
        //    var result = _context.Items
        //         .FirstOrDefault(x => x.Id == id);

        //    if (result == null)
        //    {
        //        return NotFound(); 
        //    }

        //    return ToItemsDto(result);

        //}
        [HttpGet("{articleNumber}")]
        public ActionResult<ItemsDto> GetByArticle(string articleNumber)
        {
            var result = _context.Items
                 .FirstOrDefault(x => x.ArticleNumber == articleNumber);

            if (result == null)
            {
                return NotFound();
            }

            return ToItemsDto(result);

        }

        [HttpPost]
        public async Task<ActionResult<Items>> PostItems(Items items)
        {
            _context.Items.Add(items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = items.Id }, items);
        }

        private ItemsDto ToItemsDto(Items items)
        {
            return new ItemsDto
            {
                Id = items.Id,
                ArticleNumber = items.ArticleNumber,
                Name = items.Name,
                Description = items.Description,
                AvailableStock = items.AvailableStock
            };
        }
    }
}
