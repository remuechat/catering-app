using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IMS.Domain.Models.Meals.MealItems;

// Junction entity between Meal and PreferenceTag
[Owned]
public class MealTagJunction
{
    // Primary key
    [ForeignKey(nameof(Meal))]
    public int? MealID { get; set; }
    [ForeignKey(nameof(MealTag))]
    public int? MealTagID { get; set; }

    // Navigation keys
    public Meal? Meal { get; set; }
    public MealTag? MealTag { get; set; }
}
