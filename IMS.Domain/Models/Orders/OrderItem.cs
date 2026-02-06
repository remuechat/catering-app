using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models.Orders
{
    public class OrderItem
    {
        // Junction identity
        public int OrderItemID { get; set; }
        public Guid OrderID { get; set; }

        // Junction metadata
        public int Quantity { get; set; }
    }
}
