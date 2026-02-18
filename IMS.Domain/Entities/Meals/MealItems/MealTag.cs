using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Enums;

namespace IMS.Domain.Entities.Meals.MealItems;


/// <summary>
/// Represents a tag that categorizes a meal, such as dietary preference, cuisine, or meal type.
/// This has its own table called MealTags created by OPERATOR
/// </summary>
/// 
/// <remarks>
/// Meal tags are used to organize and filter meals based on specific attributes or classifications. 
/// </remarks>

public class MealTag
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MealTagID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public MealTagType MealTagType { get; set; }
}