using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Domain.Models.Meals.MealItems;

// Has its own table called Meals
// Contains all of the meals created by OPERATOR
public class Meal
{
    // Primary key
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MealID { get; set; }
    public int OperatorID { get; set; }

    // Navigation items
    //[ForeignKey(nameof(OperatorID))]
    //private readonly AppUser? Operator;
    public virtual ICollection<MealTagJunction> MealTags { get; set; } = [];

    // Attributes
    [Required(ErrorMessage = "Meal.MealName is required.")]
    [StringLength(100, ErrorMessage = "Meal.MealName must be less than 100 characters.")]
    public string MealName { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Meal.Description must be less than 500 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Meal.MealPrice is required.")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(0.01, 1000000, ErrorMessage = "Meal.MealPrice must be greater than PHP0.01 and less than PHP1M.")]
    public decimal MealPrice { get; set; }

    [Required(ErrorMessage = "Meal.ServingSizePAX is required.")]
    [Column(TypeName = "decimal(6,2)")]
    [Range(0.1, 1000, ErrorMessage = "Meal.ServingSizePAX must be between 0.1 and 1000.")]
    public decimal ServingSizePAX { get; set; }

    [Required(ErrorMessage = "Meal.StockQuantity is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Meal.StockQuantity cannot be negative.")]
    public int StockQuantity { get; set; }

    [Required(ErrorMessage = "Meal.MinOrderQuantity is required.")]
    [Range(1, 1000, ErrorMessage = "Meal.MinOrderQuantity must be between 1 and 1000.")]
    public int MinOrderQuantity { get; set; } = 1;

    [Required(ErrorMessage = "Meal.CaloriesPerServing is required.")]
    [Range(0, 10000, ErrorMessage = "Meal.CaloriesPerServing must be between 0 and 10,000.")]
    public int CaloriesPerServing { get; set; }

    // Timestamp
    [Required(ErrorMessage = "Meal.LastCreated is required.")]
    public DateTime LastCreated { get; set; }

    [Required(ErrorMessage = "Meal.LastModifiedByUserID is required.")]
    public int LastModifiedByOperatorID { get; set; } 

    [Required(ErrorMessage = "Meal.LastModifiedDate is required.")]
    public DateTime LastModifiedDate { get; set; }

    // Optional attributes (for now)
    [Url(ErrorMessage = "Meal.ImageUrl must be a valid URL.")]
    [StringLength(500, ErrorMessage = "Meal.ImageUrl must be less than 500 characters.")]
    public string? ImageUrl { get; set; }
}
