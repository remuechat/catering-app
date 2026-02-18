using IMS.Domain.Entities.Financial.AcknowledgementReceipts;
using IMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Domain.Entities.Financial;

/// <summary>
/// For processing payments related to ORDER for online transactions.
/// TECH DEBT: Probably invert the control from pID to arID.
/// Payments can be cash-based only. 
/// </summary>

public class Payment
{
    [Key]
    [Required(ErrorMessage = "Payment ID is required")]
    [StringLength(36, ErrorMessage = "Payment ID cannot exceed 36 characters")]
    [Display(Name = "Payment ID")]
    public required string PaymentID { get; set; }

    [ForeignKey(nameof(Receipt))]
    [Required(ErrorMessage = "Acknowledgement Receipt ID is required")]
    public int AcknowledgementRecieptID { get; set; }
    public virtual AcknowledgementReceipt? Receipt { get; set; }

    [Required(ErrorMessage = "Payment Method is required")]
    [EnumDataType(typeof(PaymentMethodType), ErrorMessage = "Invalid payment method")]
    public PaymentMethodType PaymentMethod { get; set; }

    [Required(ErrorMessage = "Payment Status is required")]
    [EnumDataType(typeof(PaymentStatus), ErrorMessage = "Invalid payment status")]
    public PaymentStatus PaymentStatus { get; set; }

    [Required(ErrorMessage = "Payment date/time is required")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime TimeStamp { get; set; } = DateTime.Now;

    [Range(0, double.MaxValue, ErrorMessage = "Payment amount must be positive")]
    [Column(TypeName = "decimal(18,2)")]
    [Required(ErrorMessage = "Payment amount is required")]
    public decimal Amount { get; set; }

    [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
}
