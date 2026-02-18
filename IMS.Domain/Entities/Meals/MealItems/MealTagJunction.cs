using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IMS.Domain.Entities.Meals.MealItems;

/// <summary>
/// Junction entity that uses many [MealTag]s to categorize a [Meal] in the domain model.
/// </summary>

[Owned]
public class MealTagJunction
{
    [ForeignKey(nameof(Meal))]
    public int? MealID { get; set; }


    [ForeignKey(nameof(MealTag))]
    public int? MealTagID { get; set; }

    // Navigation entities
    public virtual Meal? Meal { get; set; }
    public virtual MealTag? MealTag { get; set; }
}
