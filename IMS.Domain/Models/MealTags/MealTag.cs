using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;

namespace IMS.Domain.Models.MealTags
{
    public class MealTag
    {
        public int MealTagID { get; set; }
        public string Name { get; set; } = string.Empty;
        public MealTagType MealTagType { get; set; }
    }
}
