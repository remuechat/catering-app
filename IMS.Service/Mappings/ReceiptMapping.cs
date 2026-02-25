
using IMS.Domain.Entities.Financial.AcknowledgementReceipts;
using System;
using System.Collections.Generic;
using System.Text;
using IMS.Service.DTOs.Financial.AcknowledgementReceipts;
using IMS.Service.DTOs.Financial.AcknowledgmentReceipts;

namespace IMS.Service.Mappings
{
    public static class ReceiptMapping
    {
        public static ReceiptSummaryDto MapToSummaryDto(AcknowledgementReceipt entity, string customerName)
        {
            return new ReceiptSummaryDto
            {
                ReceiptID = entity.AcknowledgementReceiptID,
                ReceiptNumber = entity.ReceiptNumber,
                CustomerFullName = customerName,
                IssueDate = entity.IssueDate,
                Status = entity.Status.ToString(),
                GrandTotal = entity.GrandTotal
            };
        }

        public static ReceiptDetailsDto MapToDetailsDto(AcknowledgementReceipt entity, string customerName)
        {
            return new ReceiptDetailsDto
            {
                ReceiptID = entity.AcknowledgementReceiptID,
                ReceiptNumber = entity.ReceiptNumber,
                CustomerFullName = customerName,
                IssueDate = entity.IssueDate,
                Status = entity.Status.ToString(),
                GrandTotal = entity.GrandTotal,
                // Extra details for the pop-up
                Subtotal = entity.Subtotal,
                DiscountAmount = entity.DiscountAmount,
                TaxAmount = entity.TaxAmount,
                ShippingCost = entity.ShippingCost
            };
        }
    }
}
