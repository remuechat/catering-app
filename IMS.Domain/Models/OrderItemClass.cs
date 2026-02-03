using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models
{
    public class OrderItem
    {
        public Guid OrderItemID { get; set; }
        public Guid OrderID { get; set; }
        public Guid FoodID { get; set; }
        public int Quantity { get; set; }
    }
}
