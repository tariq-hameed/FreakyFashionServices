namespace FreakyFashionServices.Basket.Models.DTO
{
    public class CreateBasketDto
    {
        public CreateBasketDto(string id, string productName, int unitPrice, int quantity)
        {
            Id = id;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public string Id { get; set; } 
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; } 

    }
}