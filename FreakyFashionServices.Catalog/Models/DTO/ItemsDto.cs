using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Catalog.Models.DTO
{
    public class ItemsDto
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }         
        public int AvailableStock { get; set; }
    }
}
