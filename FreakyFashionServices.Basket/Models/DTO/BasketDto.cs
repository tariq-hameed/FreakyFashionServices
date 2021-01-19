using System.Collections.Generic;

namespace FreakyFashionServices.Basket.Models.DTO
{
    public class BasketDto
    {
        public int Id { get; set; }

        public IList<ProductDto> Products { get; set; }   

    }
}