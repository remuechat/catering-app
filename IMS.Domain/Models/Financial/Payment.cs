using IMS.Domain.Enums;
using IMS.Domain.Models.Financial.Receipt;

namespace IMS.Domain.Models.Financial;

public class Payment
{
    // Primary key
    public required String PaymentID { get; set; }

    // Foreign/navigation keys
    public int AcknowledgementRecieptID { get; set; }
    public virtual AcknowledgementReceipt? Receipt { get; set; }

    // Payment attributes
    public PaymentMethodType PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateTime TimeStamp { get; set; }  = DateTime.Now;
}
