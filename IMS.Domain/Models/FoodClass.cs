using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum FoodType
{
    Viand,
    Rice,
    Desert,
}

namespace IMS.Domain.Models
{

    public class FoodClass { 
    
    }

    public class Food
    {
        [Required]
        [Key]
        public Guid FoodID { get; private set; }

        [Required]
        public DateTime CreatedBy { get; private set; }
        public FoodType FoodType { get; set; }

        [Required]
        public string FoodName { get; set; } = string.Empty;

        public decimal FoodPrice { get; set; }

        public bool isAlaCarte { get; set; }

        public bool isAvailable { get; set; }

        public Food()
        {
            FoodID = Guid.NewGuid();
            CreatedBy = DateTime.Now;
        }
    }

    internal class Menu
    {
        [Key]
        Guid MenuID { get; set; }
        String MenuName { get; set; }
        List<Food> FoodsInMenu { get; set; }
    }

    internal class MealOrder
    {
        [Key]
        Guid MealOrderID { get; set; }

        // CRITICAL: Make sure that this order idempotent

        DateTime OrderDate { get; set; }
        List<Food> FoodsOrdered { get; set; }
        
        decimal? TotalPrice { get; set; }

        // CHORE: evaluate this ONLY WHEN NEEDED, NOT NOW (caching strategy)
        //{ 
        //    get 
        //    {
        //        decimal total = 0;
        //        foreach (var food in FoodsOrdered)
        //        {
        //            total += food.FoodPrice;
        //        }
        //        return total;
        //    }
        //}
    }

    internal class MealPackage
    {
        [Key]
        Guid MealPackageID { get; set; }
        String PackageName { get; set; }
        List<Food>? FoodsInPackage { get; set; }
        decimal PackagePrice { get; set; }
    }

}
