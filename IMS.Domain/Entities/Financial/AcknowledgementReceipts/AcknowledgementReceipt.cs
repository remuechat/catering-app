using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Entities.Financial.Promos;
using IMS.Domain.Entities.Orders;
using IMS.Domain.Entities.Users.Identity;
using IMS.Domain.Enums;

namespace IMS.Domain.Entities.Financial.AcknowledgementReceipts;

/// <summary>
/// This is NOT a final receipt. This just recognizes that an order is checked out,
/// and an order is on the way or reserved already. 
/// 
/// TECH DEBT: Transition this Rich Domain Model into an Anemic Model later on.
/// </summary>

public class AcknowledgementReceipt
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AcknowledgementReceiptID { get; private set; }

    [Required]
    public Guid OrderID { get; set; }

    [ForeignKey("OrderID")]
    public virtual Order? Order { get; private set; }

    [Required]
    public int CustomerID { get; set; }

    [ForeignKey("CustomerID")]
    public virtual AppUser? Customer { get; private set; }

    [ForeignKey("PromoID")]
    public virtual Promo? Promo { get; set; }

    // Receipt details
    [Required]
    public DateTime IssueDate { get; set; }

    public DateTime? PaymentDate { get; private set; }

    [Required]
    [StringLength(50)]
    public string ReceiptNumber { get; set; } = string.Empty;

    [Required]
    public PaymentStatus Status { get; set; }

    public decimal Subtotal { get; set; }
    public decimal DiscountAmount { get;  set; }
    public decimal TaxAmount { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal GrandTotal { get; set; }
    public string Currency { get; set; } = "PHP";

    /*
    [Column(TypeName = "nvarchar(MAX)")]
    [StringLength(100)]
    public string Notes { get; private set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; private set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; private set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TaxAmount { get; private set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal ShippingCost { get; private set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal GrandTotal { get; private set; }

    [NotMapped]
    public decimal TaxableAmount => Subtotal - DiscountAmount;

    [Required]
    [StringLength(50)]
    public string PaymentMethod { get; private set; } = string.Empty;

    [StringLength(100)]
    public string PaymentTransactionID { get; private set; } = string.Empty;

    [Required]
    [StringLength(3)]
    public string Currency { get; private set; } = "PHP";
    */

    public AcknowledgementReceipt() { }

    /*
    public static AcknowledgementReceipt Create(
        string receiptNumber,
        Guid orderId,
        int customerID,
        string customerName,
        string customerEmail,
        decimal subtotal,
        Promo? promoId = null,
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
            CustomerID = customerID,
            Subtotal = subtotal,
            Promo = promoId,
            IssueDate = DateTime.Now,
            Status = PaymentStatus.Issued,
            Currency = "PHP"
        };

        receipt.CalculateFinancials();

        return receipt;
    }
    private void CalculateFinancials()
    {
        DiscountAmount = CalculateDiscount();

        var taxableAmount = Subtotal - DiscountAmount;
        TaxAmount = CalculateVAT(taxableAmount);

        ShippingCost = CalculateShippingCost();
        GrandTotal = taxableAmount + TaxAmount + ShippingCost;

        if (GrandTotal < 0)
            throw new InvalidOperationException("Grand total cannot be negative");
    }

    private decimal CalculateDiscount()
    {
        return Promo != null ? Subtotal * Promo.DiscountPercentageValue : 0m;
    }

    private static decimal CalculateVAT(decimal taxableAmount)
    {
        return taxableAmount * 0.12m;
    }

    private static decimal CalculateShippingCost()
    {
        return 0m;
    }
    */
}
