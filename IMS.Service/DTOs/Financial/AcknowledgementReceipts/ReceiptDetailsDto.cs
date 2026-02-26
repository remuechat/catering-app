using System;
using System.Collections.Generic;
using System.Text;
using IMS.Service.DTOs.Financial.AcknowledgementReceipts;

namespace IMS.Service.DTOs.Financial.AcknowledgmentReceipts;

public class ReceiptDetailsDto : ReceiptSummaryDto
{
    public decimal Subtotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal ShippingCost { get; set; }
    public string Notes { get; set; } = string.Empty;
}
