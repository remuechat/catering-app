using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;

namespace IMS.Domain.Models.Meals
{
    public class MealTag
    {
        // Primary key
        public int MealTagID { get; set; }

        // MealTag attributes
        public string Name { get; set; } = string.Empty;
        public MealTagType MealTagType { get; set; }
    }
}
