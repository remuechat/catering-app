using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Models.Deliveries;

namespace IMS.Domain.Models.Users.UserCart
{
    public class UserCart
    {
        public int UserID { get; set; }
        public int CartID { get; set; }
        public List<CartOrderItem> CartItems { get; set; } = new();
    }
}
