using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models.Financial.Promos
{

    public class Promo
    {
        // Primary key
        public int PromoID { get; set; }
        
        // ApplicablePromo attributes
        public string Code { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public decimal DiscountPercentageValue { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public int? UsageLimit { get; set; }
        public int UsedCount { get; set; } = 0;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsActive { get; set; } = true;

        // HELPER FUNCTIONS
        public decimal ApplyDiscount(decimal amount) { 
            return amount * DiscountPercentageValue;
        }
    }
}
