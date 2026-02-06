using System;
using System.Collections.Generic;
using IMS.Domain.Models.Financial;
using IMS.Domain.Models.Meals;

namespace IMS.Domain.Models.Packages
{
    public class MealPackage
    {
        public Guid MealPackageID { get; set; }
        public int? CateringPackageID { get; set; }
        public CateringPackage? CateringPackage { get; set; }
        public List<MealPackageItem>? MealPackageItems { get; set; } = new();
    }
}
