using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;
using IMS.Domain.Models.Orders;
using IMS.Domain.Models.Packages;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Domain.Models.Financial
{
    public class Receipt
    {
        // Primary Key
        public int ReceiptID { get; set; }

        // Foreign/navigation Keys
        public Order? Order { get; set; }
        public Guid OrderID { get; set; }
        public AppUser? User { get; set; }
        public int UserID { get; set; }
        
        // MealPackage navigation keys
        public List<MealPackage> MealPackages { get; set; } = new();

        // Receipt details
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime? PaymentDate { get; set; }

        // Promo/Memo field
        public string Notes { get; set; } = string.Empty;
        public ApplicablePromo? Promo { get; set; } // Allow for multiple applicable promos later on, depending on user need

        // Financial breakdown
        public decimal Subtotal => MealPackages?.Sum(pkg => pkg.MealPackagePrice) ?? 0;        // Sum of items before discounts
        public decimal DiscountAmount => Subtotal * (Promo?.DiscountValue ?? 0m);      // Total discounts applied
        public decimal TaxableAmount => Subtotal - DiscountAmount;
        public decimal TaxAmount => CalculateVAT();           
        public decimal ShippingCost => CalculateShippingCost();                     // Shipping calculation
        public decimal GrandTotal => TaxableAmount + TaxAmount + ShippingCost;      // Final payable amount

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

        private decimal CalculateVAT() {
            // Tax on (subtotal - discount) -> Make sure to update this AFTER VAT
            return TaxableAmount * 0.12m;
        }

        private decimal CalculateShippingCost()
        {
            return 0m;
        }
    }
}
