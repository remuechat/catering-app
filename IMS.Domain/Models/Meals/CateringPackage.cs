using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Models.Financial;

namespace IMS.Domain.Models.Meals
{
    public class CateringPackage
    {
        public int CateringPackageID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int? PromoID { get; set; }
        public Promo? Promo { get; set; }

        // Collection of meal items in this catering package
        public List<MealPackageItem> PackageItems { get; set; } = new();

        // Have an image URL or path for the catering package 
        // And have strict calling parameters here later on 
    }
}
