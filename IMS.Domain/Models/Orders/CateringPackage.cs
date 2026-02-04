using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Models.Packages;

namespace IMS.Domain.Models.Orders
{
    public class CateringPackage
    {
        [Key]
        public int CateringPackageID { get; set; }
        public virtual ICollection<MealPackage>? MealPackage { get; set; }
    }
}
