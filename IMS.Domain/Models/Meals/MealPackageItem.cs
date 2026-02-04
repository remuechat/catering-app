using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models.Meals
{
    // This is a junction item of the composite MealPackage
    // BTW: Every ala-carte meal IS a MealPackage
    // BTW: Every food package IS a MealPackage
    // ALSO: Every order IS a MealPackage
    public class MealPackageItem
    {
        // IDENTITY OF THE OBJECT
        public Guid MealPackageID { get; set; }
        public Guid MealID { get; set; }

        // ACTUAL ITEM
        public virtual Meal? Meal { get; set; }

        // METADATA ABOUT THE OBJECT
        public int RequestQuantity { get; set; }
        public String? RequestDescription { get; set; }
        public Decimal SubtotalPrice { get; set; }
    }
}
