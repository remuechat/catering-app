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
        // Primary key
        public int CateringPackageID { get; set; }

        // Foreign/navigation key
        public int? PromoID { get; set; }
        public ApplicablePromo? Promo { get; set; }
        public List<MealPackageItem> PackageItems { get; set; } = new();

        // Catering package attributes
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? CustomPrice { get; set; }

        // Have an image URL or path for the catering package 
        // And have strict calling parameters here later on 
    }
}
