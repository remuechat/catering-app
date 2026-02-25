using IMS.Application.DTOs.Logistics;
using IMS.Domain.Entities.Logistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Service.Mappings
{
    public class DeliveryMapping
    {
        public static DeliverySummaryDto MapToSummary(Delivery entity)
        {
            return new DeliverySummaryDto
            {
                DeliveryID = entity.DeliveryID,
                OrderID = entity.OrderID,
                Status = entity.Status.ToString(),
                TrackingNumber = entity.TrackingNumber,
                DeliveryAddress = entity.DeliveryAddress,
                EstimatedDeliveryDate = entity.EstimatedDeliveryDate
            };
        }

        // Maps the full record including the child updates collection
        public static DeliveryDetailsDto MapToDetailsDto(Delivery entity)
        {
            return new DeliveryDetailsDto
            {
                DeliveryID = entity.DeliveryID,
                OrderID = entity.OrderID,
                Status = entity.Status.ToString(),
                TrackingNumber = entity.TrackingNumber,
                DeliveryAddress = entity.DeliveryAddress,
                ShippingCost = entity.ShippingCost,
                CarrierName = entity.CarrierName,
                // Map each update in the collection to its DTO
                Updates = entity.DeliveryUpdates.Select(u => new DeliveryUpdateDto
                {
                    DeliveryUpdateID = u.DeliveryUpdateID,
                    Status = u.Status.ToString(),
                    UpdateDate = u.UpdateDate,
                    UpdateDescription = u.UpdateDescription,
                    Location = u.Location
                }).ToList()
            };
        }

        public static DeliveryUpdateDto MapToUpdateDto(DeliveryUpdate entity)
        {
            return new DeliveryUpdateDto
            {
                DeliveryUpdateID = entity.DeliveryUpdateID,
                DeliveryID = entity.DeliveryID,
                Status = entity.Status.ToString(),
                UpdateDate = entity.UpdateDate,
                UpdateDescription = entity.UpdateDescription,
                Location = entity.Location,
                Notes = entity.Notes,
            };
        }
    }
}
