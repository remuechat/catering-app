using System;
using IMS.Domain.Enums;

namespace IMS.Service.DTOs.Financial { 

    //from winforms (saving)
    public class PaymentCreateDto
    {
        public int AcknowledgementRecieptID { get; set; }

        public PaymentMethodType PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime TimeStamp { get; set; }

        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }

    //to UI
    public class PaymentDto
    {
        public string PaymentID { get; set; } = string.Empty;

        public int AcknowledgementRecieptID { get; set; }

        public PaymentMethodType PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime TimeStamp { get; set; }

        public decimal Amount { get; set; }
        public string? Description { get; set; } 
    }
}
