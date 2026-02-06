using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Models.Orders;

namespace IMS.Domain.Models.Users.UserCart
{
    public class CartOrderItem
    {
        public Guid OrderID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        // Order details (similar to your Order class but for shopping)
        public List<OrderItem> OrderItems { get; set; } = new();
        public decimal EstimatedTotal { get; set; }
        public string? SpecialInstructions { get; set; }
    }
}