using IMS.Domain.Enums;
using IMS.Domain.Models.Financial.Promos;
using IMS.Domain.Models.Orders;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Domain.Models.Financial.Receipt
{
    public class AcknowledgementReceipt
    {
        // Primary Key 
        public int ReceiptID { get; private set; }

        // Foreign keys
        public Guid OrderID { get; private set; }
        public int UserID { get; private set; }
        public int? PromoID { get; private set; }

        // Navigation properties
        public virtual Order Order { get; private set; }
        public virtual AppUser User { get; private set; }
        public virtual Promo? Promo { get; private set; }

        // Receipt details
        public DateTime IssueDate { get; private set; }
        public DateTime? PaymentDate { get; private set; }
        public string ReceiptNumber { get; private set; }
        public PaymentStatus Status { get; private set; }

        // Promo/Memo field
        public string Notes { get; private set; } = string.Empty;

        // Stored financial values (not calculated properties for EF compatibility)
        public decimal Subtotal { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal TaxAmount { get; private set; }
        public decimal ShippingCost { get; private set; }
        public decimal GrandTotal { get; private set; }

        // Calculated properties for business logic (not mapped to database)
        public decimal TaxableAmount => Subtotal - DiscountAmount;

        // Payment information
        public string PaymentMethod { get; private set; } = string.Empty;
        public string PaymentTransactionID { get; private set; } = string.Empty;
        public string Currency { get; private set; } = "PHP";

        // Business information
        public string CompanyName { get; private set; } = "Your Company Name";
        public string CompanyAddress { get; private set; } = string.Empty;
        public string CompanyTaxID { get; private set; } = string.Empty;

        // Customer information
        public string CustomerName { get; private set; } = string.Empty;
        public string CustomerEmail { get; private set; } = string.Empty;
        public string CustomerAddress { get; private set; } = string.Empty;

        // Private constructor for EF Core
        private AcknowledgementReceipt() { }

        // Factory method for creating receipts
        public static AcknowledgementReceipt Create(
            string receiptNumber,
            Guid orderId,
            int userId,
            string customerName,
            string customerEmail,
            decimal subtotal,
            int? promoId = null,
            string companyName = "Your Company Name")
        {
            if (string.IsNullOrWhiteSpace(receiptNumber))
                throw new ArgumentException("Receipt number is required", nameof(receiptNumber));

            if (subtotal < 0)
                throw new ArgumentException("Subtotal cannot be negative", nameof(subtotal));

            var receipt = new AcknowledgementReceipt
            {
                ReceiptNumber = receiptNumber,
                OrderID = orderId,
                UserID = userId,
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                Subtotal = subtotal,
                PromoID = promoId,
                CompanyName = companyName,
                IssueDate = DateTime.Now,
                Status = PaymentStatus.Issued,
                Currency = "PHP"
            };

            receipt.CalculateFinancials();

            return receipt;
        }

        // Main calculation method that encapsulates the business logic
        private void CalculateFinancials()
        {
            // Calculate discount
            DiscountAmount = CalculateDiscount();

            // Calculate taxable amount
            var taxableAmount = Subtotal - DiscountAmount;

            // Calculate tax
            TaxAmount = CalculateVAT(taxableAmount);

            // Calculate shipping
            ShippingCost = CalculateShippingCost();

            // Calculate grand total
            GrandTotal = taxableAmount + TaxAmount + ShippingCost;

            // Validate business rules
            if (GrandTotal < 0)
                throw new InvalidOperationException("Grand total cannot be negative");
        }

        private decimal CalculateDiscount()
        {
            // Use promo discount if available
            return Promo != null ? Subtotal * Promo.DiscountValue : 0m;
        }

        private decimal CalculateVAT(decimal taxableAmount)
        {
            // VAT calculation logic
            return taxableAmount * 0.12m;
        }

        private decimal CalculateShippingCost()
        {
            // Default shipping cost - can be extended later
            return 0m;
        }

        // Domain behavior - apply payment
        public void ApplyPayment(string paymentMethod, string transactionId, DateTime paymentDate)
        {
            if (Status != PaymentStatus.Issued)
                throw new InvalidOperationException("Cannot pay a receipt that is not in Issued status");

            if (string.IsNullOrWhiteSpace(paymentMethod))
                throw new ArgumentException("Payment method is required", nameof(paymentMethod));

            PaymentMethod = paymentMethod;
            PaymentTransactionID = transactionId;
            PaymentDate = paymentDate;
            Status = PaymentStatus.Paid;
        }

        // Domain behavior - add note
        public void AddNote(string note)
        {
            if (!string.IsNullOrWhiteSpace(note))
            {
                Notes += string.IsNullOrEmpty(Notes) ? note : $"\n{note}";
            }
        }

        // Domain behavior - update customer information
        public void UpdateCustomerInfo(string name, string email, string address)
        {
            CustomerName = name ?? CustomerName;
            CustomerEmail = email ?? CustomerEmail;
            CustomerAddress = address ?? CustomerAddress;
        }

        // Domain behavior - void receipt
        public void VoidReceipt(string reason)
        {
            if (Status == PaymentStatus.Paid)
                throw new InvalidOperationException("Cannot void a paid receipt without refund process");

            Status = PaymentStatus.Voided;
            AddNote($"Receipt voided: {reason}");
        }

        // Helper method to get calculated values (for UI or reporting)
        public AcknowledgementReceiptSummary GetSummary()
        {
            return new AcknowledgementReceiptSummary
            {
                Subtotal = Subtotal,
                DiscountAmount = DiscountAmount,
                TaxAmount = TaxAmount,
                ShippingCost = ShippingCost,
                GrandTotal = GrandTotal,
                TaxableAmount = TaxableAmount
            };
        }
    }


}
