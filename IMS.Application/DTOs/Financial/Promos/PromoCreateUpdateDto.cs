using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Presentation.DTOs.Financial.Promos
{
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
