using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models.Orders
{
    public class OrderItem
    {
        // Primary key
        public int OrderItemID { get; set; }

        // Foreign/navigation keys
        public Guid OrderID { get; set; }

        // Order item attributes
        public int Quantity { get; set; }
    }
}
