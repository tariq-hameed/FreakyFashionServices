using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Model.DTO
{
    public class OrdersDto
    {
        public int Id { get; set; }
        public string CustomerIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
