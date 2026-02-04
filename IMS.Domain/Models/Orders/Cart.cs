using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models.Orders
{
    public class Cart
    {
        [Key] // should NOT be a primary key, should follow a user instead
        Guid CartID { get; set; }

        // this should be 
        public virtual ICollection<Order>? CartItems { get; set; }
    }
}
