
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
            if (dto == null) return new ReceiptViewModel();
            return new ReceiptViewModel
            {
                ReceiptID = dto.ReceiptID,
                ReceiptNumber = dto.ReceiptNumber ?? "N/A",
                // Since CustomerName uses SetProperty, this will trigger the UI update correctly
                CustomerName = dto.CustomerFullName ?? "Unknown",
                FormattedDate = dto.IssueDate.ToString("MMM dd, yyyy"),
                Status = dto.Status ?? "Unpaid",
                TotalDisplay = "₱" + dto.GrandTotal.ToString("N2")
            };
        }

        // full Details (for the Pop-up/Details View)
        public static ReceiptViewModel MapToViewModel(ReceiptDetailsDto dto)
        {
            if (dto == null) return new ReceiptViewModel();

            // Leveraging the summary mapper for common fields
            var vm = MapToViewModel((ReceiptSummaryDto)dto);

            // These are auto-properties in ViewModel, so they map directly
            vm.Subtotal = dto.Subtotal;
            vm.DiscountAmount = dto.DiscountAmount;
            vm.TaxAmount = dto.TaxAmount;
            vm.GrandTotal = dto.GrandTotal;

            return vm;
        }
    }
}
