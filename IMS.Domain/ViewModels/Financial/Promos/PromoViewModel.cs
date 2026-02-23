using System;

namespace IMS.Domain.ViewModels.Financial.Promos
{
    public class PromoViewModel
    {
        public int PromoID { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Discount { get; set; } = string.Empty;
        public string MinimumOrder { get; set; } = string.Empty;

        public string UsageInfo {  get; set; } = string.Empty;
        public string ValidPeriod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}


//mapping to viewmodel -- to be inserted in ui

/*private PromoViewModel MapToViewModel(PromoDto dto)
{
    return new PromoViewModel
    {
        PromoID = dto.PromoID,
        Code = dto.Code,
        Description = dto.Description,

        Discount = dto.DiscountPercentageValue.ToString("0.##") + "%",

        MinimumOrder = dto.MinimumOrderAmount.HasValue
            ? "₱" + dto.MinimumOrderAmount.Value.ToString("N2")
            : "None",

        UsageInfo = dto.UsageLimit.HasValue
            ? $"{dto.UsedCount}/{dto.UsageLimit}"
            : "Unlimited",

        ValidPeriod = $"{dto.ValidFrom:MMM dd, yyyy} - {dto.ValidUntil:MMM dd, yyyy}",

        Status = dto.IsActive ? "Active" : "Inactive"
    };
}
*/