using IMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Service.DTOs.Meals
{
    public class MealTagDto
    {
        public int MealTagID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MealTagType MealTagType { get; set; }
    }

    public class MealSummaryDto
    {
        public int MealID { get; set; }
        public string MealName { get; set; } = string.Empty;
        public decimal MealPrice { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class MealDetailsDto : MealSummaryDto
    {
        public string? Description { get; set; }
        public decimal ServingSizePAX { get; set; }
        public int MinOrderQuantity { get; set; }
        public int CaloriesPerServing { get; set; }
        public DeliveryType DeliveryType { get; set; }
        //replacing the junction in the dto layer
        public List<MealTagDto> Tags { get; set; } = new();   
    }
}
