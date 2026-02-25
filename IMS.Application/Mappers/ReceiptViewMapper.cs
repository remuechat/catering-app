
using IMS.Application.ViewModels.Financial.Receipt;
using IMS.Service.DTOs.Financial.AcknowledgementReceipts;
using IMS.Service.DTOs.Financial.AcknowledgmentReceipts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Application.Mappers
{
    public static class ReceiptViewMapper
    {
        // summary (for the Grid/List)
        public static ReceiptViewModel MapToViewModel(ReceiptSummaryDto dto)
        {
            return new ReceiptViewModel
            {
                ReceiptID = dto.ReceiptID,
                ReceiptNumber = dto.ReceiptNumber,
                CustomerName = dto.CustomerFullName,
                FormattedDate = dto.IssueDate.ToString("MMM dd, yyyy"),
                Status = dto.Status,
                TotalDisplay = "P" + dto.GrandTotal.ToString("N2") 
            };
        }

        // full Details (for the Pop-up/Details View)
        public static ReceiptViewModel MapToViewModel(ReceiptDetailsDto dto)
        {
            var vm = MapToViewModel((ReceiptSummaryDto)dto); 

            vm.Subtotal = dto.Subtotal;
            vm.DiscountAmount = dto.DiscountAmount;
            vm.TaxAmount = dto.TaxAmount;
            vm.GrandTotal = dto.GrandTotal;

            return vm;
        }
    }
}
