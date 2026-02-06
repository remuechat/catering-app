using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Enums
{
    public enum DeliveryType
    {
        Standard = 0,  // Standard delivery (3-5 business days)
        Express = 1,   // Express delivery (1-2 business days)
        SameDay = 2,   // Same day delivery (within 24 hours)
        Overnight = 3, // Overnight delivery (next business day)
        Pickup = 4     // Customer pickup from store/location
    }
}
