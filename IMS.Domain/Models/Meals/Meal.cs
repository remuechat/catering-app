using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;

namespace IMS.Domain.Models.Meals
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealId { get; set; }

        [Required]
        [StringLength(100)]
        public string MealName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal MealPrice { get; set; }

        public MealCategory MealCategory { get; set; }

        public int StockQuantity { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedByUserId { get; set; } = string.Empty;

        public int MinOrderQuantity { get; set; } = 1;
        public float ServesNumberOfPeople { get; set;  } = 1.0f;

        public int CaloriesPerServing { get; set; }
        public virtual ICollection<DietaryCategory> DietaryCategoryType { get; set; } = 
            new List<DietaryCategory>();
        
        // THIS SHOULD HAVE AN IMAGE! 
    }
}
