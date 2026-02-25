using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Presentation.DTOs.Financial.AcknowledgementReceipts
{
    public class ReceiptDetailsDto : ReceiptSummaryDto
    {
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
