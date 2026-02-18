using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Contracts.Meals.MealItems.Server;

public class MealRequestDto
{
    public int MealID { get; set; }
    public int AppUserID { get; set; }
}
