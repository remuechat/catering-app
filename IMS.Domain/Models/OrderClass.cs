using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;

namespace IMS.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; } = Guid.NewGuid();
        public DateTime OrderDate { get; } = DateTime.Now;
        public DeliveryType DeliveryType { get; set; }
        public String? Address { get; set; } // integrate Google Maps API later
        public Boolean IsInPoblacion { get; set; } // integrate Google Maps API later
        public int GoodForPax { get; set; }
        // add image later on
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
