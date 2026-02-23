using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Entities.Meals.MealItems;
using Microsoft.EntityFrameworkCore;

namespace IMS.Domain.Entities.Meals.MealProduct;

/// <summary>
/// This is a junction entity owned by MealProduct.
/// Represents a product item included in a meal, specifying the 
/// associated meal, quantity, and any special requests.
/// </summary>

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
