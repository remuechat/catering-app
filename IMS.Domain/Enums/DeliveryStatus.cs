using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Enums
{
    public enum DeliveryStatus
    {
        OnCart = 0,
        Pending = 1,        // Order received, delivery not yet scheduled
        Scheduled = 2,      // Delivery scheduled for a specific date/time
        Preparing = 3,      // Order being prepared for delivery
        ReadyForPickup = 4, // Order ready for delivery personnel to pick up
        OutForDelivery = 5, // Order picked up and out for delivery
        InTransit = 6,      // Order in transit to destination
        Arrived = 7,        // Delivery personnel arrived at location
        Attempted = 8,      // Delivery attempted but unsuccessful
        Delivered = 9,      // Successfully delivered
        Failed = 10,         // Delivery failed (multiple attempts)
        Cancelled = 11,     // Delivery cancelled
        Returned = 12       // Order returned to sender
    }
}
