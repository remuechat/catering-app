using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Models.Financial
{

    public class Promo
    {
        public int PromoID { get; set; }
        public string Code { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public int? UsageLimit { get; set; }
        public int UsedCount { get; set; } = 0;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsActive { get; set; } = true;
        public List<int> ApplicableProductIDs { get; set; } = new();
        public List<int> ApplicableUserIDs { get; set; } = new();    
    
    }
}
