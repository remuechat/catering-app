

using IMS.Domain.Entities.Logistics;
using IMS.Domain.Enums;
using IMS.Domain.Interfaces;
using IMS.Service.DTOs.Logistics;
using IMS.Service.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Service.Services.Logistics
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IDeliveryUpdateRepository _updateRepository;

        public DeliveryService(
            IDeliveryRepository deliveryRepository,
            IDeliveryUpdateRepository updateRepository)
        {
            _deliveryRepository = deliveryRepository;
            _updateRepository = updateRepository;
        }

        public async Task<DeliveryUpdateDto> AddDeliveryUpdateAsync(int deliveryId, string status, string description, string? location, int updatedByUserId)
        {
            // create the new update entity
            var update = new DeliveryUpdate
            {
                DeliveryID = deliveryId,
                Status = Enum.Parse<DeliveryStatus>(status),
                UpdateDate = DateTime.Now,
                UpdateDescription = description,
                Location = location,
                UpdatedByUserID = updatedByUserId
            };

            // save the update through the repository
            await _updateRepository.AddAsync(update);

            // update the main Delivery record's current status
            var delivery = await _deliveryRepository.GetByIdAsync(deliveryId);
            if (delivery != null)
            {
                delivery.Status = update.Status;
                delivery.CurrentLocation = update.Location;
                delivery.LastLocationUpdate = update.UpdateDate;
                await _deliveryRepository.UpdateAsync(delivery);
            }

            return DeliveryMapping.MapToUpdateDto(update);
        }

        public async Task<IEnumerable<DeliverySummaryDto>> GetDeliveriesByOrderAsync(Guid orderId)
        {
            //Call the repo method from your interface
            var deliveries = await _deliveryRepository.GetDeliveriesByOrderIdAsync(orderId);
            
            // Map the collection
            return deliveries.Select(d => DeliveryMapping.MapToSummary(d));
        }

        public async Task<DeliveryDetailsDto> GetDeliveryDetailsAsync(int deliveryId)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(deliveryId);
            if (delivery == null) return null;

            // Map to the Details DTO directly
            var dto = DeliveryMapping.MapToDetailsDto(delivery);

            // Map the child collection
            dto.Updates = delivery.DeliveryUpdates
                .Select(u => DeliveryMapping.MapToUpdateDto(u))
                .ToList();

            return dto;
        }
    }
}
