using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.ProductPrice.Models.DTO
{
    public class PricesDto
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Price { get; set; }
    }
}
