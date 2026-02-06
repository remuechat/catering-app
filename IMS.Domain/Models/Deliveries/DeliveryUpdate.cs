using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;
using IMS.Domain.Models.Users.Identity; // Ensure that the correct Delivery type is referenced.

namespace IMS.Domain.Models.Deliveries
{
    public class DeliveryUpdate
    {
        public int DeliveryUpdateID { get; set; }
        public int DeliveryID { get; set; }
        public Delivery Delivery { get; set; } = new Delivery();

        public DeliveryStatus Status { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string UpdateDescription { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Notes { get; set; }

        // Optional: Who made the update (system, customer, delivery personnel)
        public string UpdatedBy { get; set; } = "System";
        public int? UpdatedByUserID { get; set; }
        public AppUser? UpdatedByUser { get; set; }
    }
}

