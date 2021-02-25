using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.ProductPrice.Models.Domain
{
    class Prices
    {
        public Prices(int id, string articleNumber, string price)
        {
            Id = id;
            ArticleNumber = articleNumber;
            Price = price;
        }

        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Price { get; set; } 
    }
}
