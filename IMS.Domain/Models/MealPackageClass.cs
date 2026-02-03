using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models
{
    public class MealPackage
    {
        [Key]
        public Guid MealPackageID { get; set; }
        public String? PackageName { get; set; }
        public virtual ICollection<OrderItem>? MenuItems { get; set; }
    }
}
