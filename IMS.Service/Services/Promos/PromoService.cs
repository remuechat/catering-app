
using IMS.Domain.Entities.Financial.Promos;
using System;
using IMS.Service.DTOs.Financial.Promos;
using IMS.Service.Mappings;

namespace IMS.Service.Services.Promos
{
    public class PromoService
    {
        public bool CanApplyPromo(Promo promo, decimal orderAmount)
        {
            if (!promo.IsActive) 
                return false;
            if (promo.MinimumOrderAmount.HasValue && orderAmount < promo.MinimumOrderAmount.Value)
                return false;
            if (DateTime.Today < promo.ValidFrom || DateTime.Today > promo.ValidUntil) return false;
            return true;
        }

        public decimal CalculateDiscount(Promo promo, decimal orderAmount)
        {
            return orderAmount * (promo.DiscountPercentageValue / 100m);
        }

        public decimal ApplyDiscount(Promo promo, decimal orderAmount)
        {
            if (!CanApplyPromo(promo, orderAmount))
                return orderAmount;
             var discount = CalculateDiscount(promo, orderAmount);
            return orderAmount - discount;
        }

        public void IncrementUsage(Promo promo)
        {
            if (promo.UsageLimit.HasValue && promo.UsedCount >= promo.UsageLimit.Value)
                throw new InvalidOperationException("Promo usage limit reached.");

            promo.UsedCount++;
        }



        //CreatePromoAsync uses PromoCreateUpdateDto to
        //prevent users from manually setting internal fields like UsedCount during the initial save.
        public async Task<bool> CreatePromoAsync(PromoCreateUpdateDto dto)
        {
            if (dto == null) return false;
            //converting input dto to a db entity
            var promoEntity = PromoMapping.MapToEntity(dto);

            promoEntity.Code = dto.Code.ToUpper();

            //saving to db
            // _context.Promos.Add(promoEntity);
            // return await _context.SaveChangesAsync() > 0;

            return await Task.FromResult(true);
        }
    }
}
