using System;

namespace IMS.Domain.DTO.Financial.Promos
{
    public class PromosDto
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal DiscountPercentageValue { get; set; }
        public decimal? MinimumOrderAmount { get; set; }

        public int? UsageLimit { get; set; }
        public int UsedCount { get; set; } = 0;

        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }

        public bool IsActive { get; set; } = true;

    }

    //Used when adding/editing promo

    public class PromoCreateUpdateDto
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal DiscountPercentageValue { get; set; }
        public decimal? MinimumOrderAmount { get; set; }

        public int? UsageLimit { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
