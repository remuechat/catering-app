using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;
using IMS.Domain.Models.Packages;

namespace IMS.Domain.Models.Financial
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public Guid OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime? PaymentDate { get; set; }

        // Line items and details
        public List<MealPackage> Items { get; set; } = new();

        // Financial breakdown
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DiscountAmount { get; set; }
        

        // Payment information
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentTransactionID { get; set; } = string.Empty;
        public string Currency { get; set; } = "PHP";

        // Status and tracking
        public PaymentStatus Status { get; set; } = PaymentStatus.Issued;
        public string ReceiptNumber { get; set; } = string.Empty; 


        // Business information -> insert this later on
        public string CompanyName { get; set; } = "Your Company Name";
        public string CompanyAddress { get; set; } = string.Empty;
        public string CompanyTaxID { get; set; } = string.Empty;

        // Customer information
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;

        // Promo/Memo field
        public string Notes { get; set; } = string.Empty;
        public string PromoCodeUsed { get; set; } = string.Empty;
    }
}
