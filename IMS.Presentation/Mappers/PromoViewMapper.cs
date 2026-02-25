using IMS.Presentation.DTOs.Financial.Promos;
using IMS.Presentation.ViewModels.Financial.Promos;

namespace IMS.Presentation.Mappers
{
    public static class PromoViewMapper
    {
        public static PromoViewModel MapToViewModel(PromoDto dto)
        {
            if (dto == null) return new PromoViewModel();

            return new PromoViewModel
            {
                PromoID = dto.PromoID,
                Code = dto.Code ?? string.Empty,

                DiscountValue = dto.DiscountPercentageValue,

                //OrderMealProduct -> MealProduct + Promo -> Final Price
                MinimumOrder = dto.MinimumOrderAmount ?? 0,

                Status = dto.IsActive ? "Active" : "Inactive"
            };
        }
    }
}