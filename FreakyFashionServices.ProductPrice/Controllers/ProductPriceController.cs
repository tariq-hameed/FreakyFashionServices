using FreakyFashionServices.ProductPrice.Models.Domain;
using FreakyFashionServices.ProductPrice.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.ProductPrice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductPriceController : ControllerBase
    {
        //private static readonly List<Prices> Prices = new List<Prices>
        //{
        //    new Prices(
        //        id: 1,
        //        articleNumber: "ABC123",
        //        price: "199"),
        //    new Prices(
        //        id: 2,
        //        articleNumber: "CBA321",
        //        price: "299"),
        //    new Prices(
        //        id: 3,
        //        articleNumber: "AAA123",
        //        price: "399")
        //};

        //// GET/ProductPrice/ABC123
        //[HttpGet("{articleNumber}")]
        //public ActionResult<PricesDto> GetProductpris(string articleNumber)
        //{
        //    var foundProduct = Prices
        //        .FirstOrDefault(x => x.ArticleNumber == articleNumber);

        //    if (foundProduct is null)
        //    {
        //        return NotFound(); // 404 Not Found
        //    }

        //    var dto = new PricesDto
        //    {
        //        Id = foundProduct.Id,
        //        ArticleNumber = foundProduct.ArticleNumber,
        //        Price = foundProduct.Price,

        //    };

        //    return dto;
        //}
        //[HttpGet]
        //public IEnumerable<PricesDto> GetAll()
        //{
        //    var myItems = Prices.ToList();
        //    var projectedItems = myItems.Select(x => new PricesDto
        //    {
        //        Id = x.Id,
        //        ArticleNumber = x.ArticleNumber,
        //        Price = x.Price
        //    });
        //    return projectedItems;
        //}
        //[HttpGet]
        //public IEnumerable<ProductPrice> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new ProductPrice
        //    {               
        //        Price = rng.Next(100, 300),                
        //    })
        //    .ToArray();
        //}

        [HttpGet("{id}")]
        public ActionResult<ProductPrice> GetById()
        {
            var rng = new Random();
            var result = new ProductPrice
            {
                Price = rng.Next(100, 300)
            };
            return result;

        }
    }
}
