
using IMS.Service.DTOs.Logistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Service.Services.Logistics
{
    internal interface IDeliveryService
    {

        /// <summary>
        /// Fetches a single delivery record and converts it to a detailed DTO, 
        /// including the full history of delivery updates.
        /// </summary>
        Task<DeliveryDetailsDto> GetDeliveryDetailsAsync(int deliveryId);
    
        /// <summary>
        /// Retrieves all delivery records associated with a specific Order GUID.
        /// </summary>
        Task<IEnumerable<DeliverySummaryDto>> GetDeliveriesByOrderAsync(Guid orderId);
    
        /// <summary>
        /// Creates a new DeliveryUpdate entry and synchronizes the main Delivery 
        /// record's status and location.
        /// </summary>
        Task<DeliveryUpdateDto> AddDeliveryUpdateAsync(
            int deliveryId,
            string status,
            string description,
            string? location,
            int updatedByUserId);
    }
}
