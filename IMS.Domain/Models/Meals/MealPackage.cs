using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Models.Financial;
using IMS.Domain.Models.Meals;

namespace IMS.Domain.Models.Packages
{
    // MENU IS JUST A PACKAGE!
    public class MealPackage
    {
        // meal package identifier
        // this is a composite object made of the junction object MealPackageItem
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealPackageID { get; set; }


        // meal package metadata
        [Required]
        [StringLength(100)]
        public string PackageName { get; set; } = string.Empty;
        public string? PackageDescription { get; set; }

        // meal package costing and discounting
        public decimal TotalPrice { get; set; } 
        public virtual Promo? Promo { get; set; }

        // collection of each meal package
        public virtual ICollection<MealPackageItem>? MealPackageItems { get; set; }
    }
}
