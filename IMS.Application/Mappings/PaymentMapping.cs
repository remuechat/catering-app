using IMS.Presentation.DTOs.Financial;
using IMS.Domain.Entities.Financial;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Presentation.Mappings
{
    public static class PaymentMapping
    {
        // Maps Entity to DTO (for display in UI)
        public static PaymentDto MapToDto(Payment entity)
        {
            if (entity == null) return new PaymentDto();

            return new PaymentDto
            {
                PaymentID = entity.PaymentID,
                AcknowledgementRecieptID = entity.AcknowledgementRecieptID,
                PaymentMethod = entity.PaymentMethod,
                PaymentStatus = entity.PaymentStatus,
                TimeStamp = entity.TimeStamp,
                Amount = entity.Amount,
                Description = entity.Description
            };
        }

        // Maps CreateDto to Entity (for saving from WinForms)
        public static Payment? MapToEntity(PaymentCreateDto dto)
        {
            if (dto == null) return null;

            return new Payment
            {
                PaymentID = Guid.NewGuid().ToString(),
                AcknowledgementRecieptID = dto.AcknowledgementRecieptID,
                PaymentMethod = dto.PaymentMethod,
                PaymentStatus = dto.PaymentStatus,
                TimeStamp = dto.TimeStamp,
                Amount = dto.Amount,
                Description = dto.Description
            };
        }
    }
}
