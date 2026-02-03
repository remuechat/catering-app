using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models
{
    public class Menu
    {
        [Key]
        Guid MenuID { get; set; }
        String? MenuName { get; set; }
        public virtual ICollection<OrderItem>? MenuItems { get; set; }
    }
}
