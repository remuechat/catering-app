using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    // This is a junction item of the composite MealPackage
    // BTW: Every ala-carte meal IS a MealPackage
    // BTW: Every food package IS a MealPackage
    // ALSO: Every order IS a MealPackage


namespace IMS.Domain.Models.Meals
    {
        public class MealPackageItem
        {
            // Primary key
            public Guid MealPackageItemID { get; set; } 

            // Foreign/navigation keys
            public Guid MealPackageID { get; set; }
            public int MealID { get; set; }
            public Meal? Meal { get; set; }
         
            // Meal attributes
            public int RequestQuantity { get; set; }
            public string? RequestDescription { get; set; }
            public decimal Price { get; set; }
        }
    }
