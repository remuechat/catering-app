using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Enums
{
    public enum DeliveryStatus
    {
        Pending,
        Received,
        Preparing,
        Delivering,
        Delivered,
        Cancelled,
    }
}
