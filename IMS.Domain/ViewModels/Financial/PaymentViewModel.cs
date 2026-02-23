using System;

namespace IMS.Domain.ViewModels.Financial
{
    public class PaymentViewModel
    {
        public string PaymentID { get; set; } = string.Empty;

        public int ReceiptID { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;

        public string TimeStamp { get; set; } = string.Empty;

        public string Amount { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

/* for mapping 
private PaymentViewModel MapToViewModel(PaymentDto dto) {
 return new PaymentViewModel
    {
        PaymentID = dto.PaymentID,
        ReceiptID = dto.AcknowledgementRecieptID,

        PaymentMethod = dto.PaymentMethod.ToString(),

        PaymentStatus = dto.PaymentStatus.ToString(),

        TimeStamp = dto.TimeStamp
                        .ToString("MMM dd, yyyy hh:mm tt"),

        Amount = "₱" + dto.Amount.ToString("N2"),

        Description = dto.Description ?? "-"
    };
}
*/