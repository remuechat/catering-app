
using System;
using System.Collections.Generic;
using System.Text;
using IMS.Service.DTOs.Financial;
using IMS.Application.ViewModels.Financial;

namespace IMS.Application.Mappers
{
    public static class PaymentViewMapper
    {
        public static PaymentViewModel MapToViewModel(PaymentDto dto)
        {
            if (dto == null) return new PaymentViewModel();

            return new PaymentViewModel
            {
                PaymentID = dto.PaymentID,
                ReceiptID = dto.AcknowledgementRecieptID,

                // Converting Enums to readable Strings
                PaymentMethod = dto.PaymentMethod.ToString(),
                PaymentStatus = dto.PaymentStatus.ToString(),

                // Formatting based on your specific requirements
                TimeStamp = dto.TimeStamp.ToString("MMM dd, yyyy hh:mm tt"),
                Amount = "P" + dto.Amount.ToString("N2"),
                Description = dto.Description ?? "-"
            };
        }
    }
}
