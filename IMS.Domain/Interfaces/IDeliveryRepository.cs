using IMS.Domain.Entities.Logistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Interfaces
{
    public interface IDeliveryRepository
    {
        // Fetches a single delivery with its full update history
        Task<Delivery?> GetByIdAsync(int deliveryId);

        // Fetches all deliveries for a specific order
        Task<IEnumerable<Delivery>> GetDeliveriesByOrderIdAsync(Guid orderId);
        
        // Updates the status and tracking info on the main record
        Task UpdateAsync(Delivery delivery);
        
    }

    public interface IDeliveryUpdateRepository
    {
        //saves a new status upate to the history timeline
        Task AddAsync(Delivery update);
        Task AddAsync(DeliveryUpdate update);

        //fetches all updates for a specific delivery
        Task<IEnumerable<DeliveryUpdate>> GetUpdatesByDeliveryIdAsync(int deliveryId);
    }
}
