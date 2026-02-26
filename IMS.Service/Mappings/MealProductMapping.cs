using IMS.Domain.Entities.Meals.MealProduct;
using IMS.Service.DTOs.Meals;

namespace IMS.Service.Mappings
{
    public static class MealProductMapping
    {
        //enityt -> dto
        public static MealProductDto MapToDto(MealProduct entity)
        {
            if (entity == null) return null!;
            return new MealProductDto
            {
                MealProductID = entity.MealProductID,
                OwnerID = entity.OwnerID,
                PromoID = entity.PromoID,
                ProductName = entity.ProductName,
                ProductDescription = entity.ProductDescription,
                ProductBasePrice = entity.ProductBasePrice,
                DiscountAmount = entity.DiscountAmount,
                FinalPrice = entity.FinalPrice,
                MealProductItems = entity.MealProductItems.Select(i => new MealProductItemDto
                {
                    MealID = i.MealID,
                    MealName = i.Meal?.MealName ?? "Unknown",
                    Quantity = i.Quantity,
                    ItemPrice = i.ItemPrice,
                    RequestDescription = i.RequestDescription,
                }).ToList()
            };
        }

        public static MealProduct MapToEntity(MealProductDto dto)
        {
            if (dto == null) return null!;
            return new MealProduct
            {
                MealProductID = dto.MealProductID,
                OwnerID = dto.OwnerID,
                PromoID = dto.PromoID,
                ProductName = dto.ProductName,
                ProductDescription = dto.ProductDescription,
                MealProductItems = dto.MealProductItems.Select(i => new MealProductItem
                {
                    MealID = i.MealID,
                    Quantity = i.Quantity,
                    RequestDescription = i.RequestDescription
                }).ToList()
            };
        }
    }
}
