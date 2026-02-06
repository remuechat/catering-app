using System;
using System.Collections.Generic;
using IMS.Domain.Enums;

namespace IMS.Domain.Models.Meals
{
    public class Meal
    {
        // Primary key
        public int MealID { get; set; }

        // Meal attributes
        public string MealName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal MealPrice { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; } = string.Empty;
        public int MinOrderQuantity { get; set; } = 1;
        public float ServesNumberOfPeople { get; set; } = 1.0f;
        public int CaloriesPerServing { get; set; }
        public List<MealTag> MealTags { get; set; } = new();

        // THIS SHOULD HAVE AN IMAGE! 
        // Consider adding: public string? ImageUrl { get; set; }
    }
}
