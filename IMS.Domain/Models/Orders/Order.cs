using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;
using IMS.Domain.Models.Packages;

namespace IMS.Domain.Models.Orders
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; } = Guid.NewGuid();
        public DateTime OrderDate { get; } = DateTime.Now;
        public DeliveryCategory DeliveryType { get; set; }
        public String? Address { get; set; } // integrate Google Maps API later
        public Boolean IsInPoblacion { get; set; } // integrate Google Maps API later
        // add image later on
        public virtual ICollection<MealPackage>? MealPackage { get; set; }
    }
}
