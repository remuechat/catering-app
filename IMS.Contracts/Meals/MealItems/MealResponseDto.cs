

using System.Runtime.CompilerServices;
using IMS.Domain.Models.Meals.MealItems;

namespace IMS.Contracts.Meals.MealItems;

public class MealResponseDto
{
    public int MealID { get; private set; }
    public int OperatorID { get; private set; }
    public List<MealTag>? MealTags {get; private set;}
    public string MealName { get; private set; } = string.Empty;
    public string MealDescription { get; private set; } = string.Empty;
    public decimal ServingSizePAX { get; private set; }
    public int StockQuantity { get; private set; }
    public int MinOrderQuantity { get; private set; }
    public int CaloriesPerServing { get; private set; }
    public DateTime LastCreated { get; private set; }
    public DateTime LastUpdated { get; private set; }
    public string ImageUrl { get; private set; } = string.Empty;
}
