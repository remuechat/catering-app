
using IMS.Domain.Entities.Meals.MealItems;
using IMS.Service.DTOs.Meals;

namespace IMS.Service.Mappings.Meals;

public static class MealMapping
{
    //meal entity to summary dto
    public static MealSummaryDto MapToSummaryDto(Meal entity)
    {
        return new MealSummaryDto
        {
            MealID = entity.MealID,
            MealName = entity.MealName,
            MealPrice = entity.MealPrice,
            StockQuantity = entity.StockQuantity,
            ImageUrl = entity.ImageUrl,
        };
    }

    //meal entity to detailed dto (w/ junction data)
    public static MealDetailsDto MapToDetailsDto(Meal entity, IEnumerable<MealTag> tags)
    {
        return new MealDetailsDto
        {
            MealID = entity.MealID,
            MealName = entity.MealName,
            Description = entity.Description,
            MealPrice = entity.MealPrice,
            ServingSizePAX = entity.ServingSizePAX,
            StockQuantity = entity.StockQuantity,
            MinOrderQuantity = entity.MinOrderQuantity,
            CaloriesPerServing = entity.CaloriesPerServing,
            DeliveryType = entity.DeliveryType,
            ImageUrl = entity.ImageUrl,
            Tags = tags.Select(t => new MealTagDto
            {
                MealTagID = t.MealTagID,
                Name = t.Name,
                MealTagType = t.MealTagType,
            }).ToList()
        };
    }
}
