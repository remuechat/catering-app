using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Models.Meals.MealItems;
using Microsoft.EntityFrameworkCore;

namespace IMS.Domain.Models.Meals.MealProduct;

// Junction entity owned by MealProduct
[Owned]
public class MealProductItem
{
    [ForeignKey(nameof(Meal))]
    public int MealID { get; set; }
    public virtual Meal? Meal { get; set; }

    [Range(1, 500)]
    public int Quantity { get; set; } = 1;

    [StringLength(500)]
    public string? RequestDescription { get; set; }

    [NotMapped]
    public decimal ItemPrice => Meal?.MealPrice * Quantity ?? 0m;
}
