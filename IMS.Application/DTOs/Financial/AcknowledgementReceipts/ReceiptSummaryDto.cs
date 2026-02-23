using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Presentation.DTOs.Financial.AcknowledgementReceipts
{
    public class ReceiptSummaryDto
    {
        public int ReceiptID { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public string CustomerFullName { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal GrandTotal { get; set; }
    }
}
