
using IMS.Domain.Entities.Financial.Promos;
using System.Globalization;
using IMS.Service.DTOs.Financial.Promos;

namespace IMS.Service.Mappings
{
    public static class PromoMapping //class wrapper
    {
       public static PromoDto MapToDto(Promo entity)
        {
            if (entity == null) return new PromoDto();

            return new PromoDto
            {
                PromoID = entity.PromoID,
                Code = entity.Code,
                Description = entity.Description,
                DiscountPercentageValue = entity.DiscountPercentageValue, //raw decimal
                MinimumOrderAmount = entity.MinimumOrderAmount,
                ValidFrom = entity.ValidFrom,
                ValidUntil = entity.ValidUntil,
                IsActive = entity.IsActive,
                UsageLimit = entity.UsageLimit,
                UsedCount = entity.UsedCount
            };
        }

        public static Promo MapToEntity(PromoDto dto)
        {
            if (dto == null) return new Promo();

            return new Promo
            {
                // [Left Side: Entity Attribute] = [Right Side: DTO Attribute]
                PromoID = dto.PromoID,
                Code = dto.Code,
                Description = dto.Description,
                DiscountPercentageValue = dto.DiscountPercentageValue,
                MinimumOrderAmount = dto.MinimumOrderAmount,
                ValidFrom = dto.ValidFrom,
                ValidUntil = dto.ValidUntil,
                UsageLimit = dto.UsageLimit,
            };
        }

        public static Promo? MapToIdentity(PromoCreateUpdateDto dto)
        {
            if (dto == null) return null;

            return new Promo
            {
                Code = dto.Code,
                Description = dto.Description,
                DiscountPercentageValue = dto.DiscountPercentageValue,
                MinimumOrderAmount = dto.MinimumOrderAmount,
                ValidFrom = dto.ValidFrom,
                ValidUntil = dto.ValidUntil,
                UsageLimit = dto.UsageLimit,
                // UsedCount starts at 0 by default in the database
            };
        }

        internal static object MapToEntity(PromoCreateUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
