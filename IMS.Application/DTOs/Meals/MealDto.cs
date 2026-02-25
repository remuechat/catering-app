using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Presentation.DTOs.Meals
{
    public class MealDto
    {
        public int MealID { get; set; }

        //User
        public int RecipientID { get; set; }
        public string? RecipientName { get; set; }

        //Meal data
        public string MealName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal MealPrice { get; set; }
        public string? ImageUrl { get; set; }

        //Logistics
        public decimal MealPrice { get; set; }
        public decimal ServingSizePAX { get; set; }
        public int StockQuantity { get; set; }
        public int CaloriesPerServing { get; set; }

        //Delivery
        public string DeliveryType { get; set; } = sstring.Empty;
        public int DeliveryType { get; set; }

        //ModifiedBy
        public string? ModifiedByOperatorName { get; set; }
    }
}
