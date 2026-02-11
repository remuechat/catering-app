using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;
using IMS.Domain.Models.Users.Identity;
using Microsoft.EntityFrameworkCore;

namespace IMS.Domain.Models.Logistics.Delivery
{
    public class DeliveryUpdate
    {
        public int DeliveryUpdateID { get; set; }
        
        // Foreign and navigation keys
        public int DeliveryID { get; set; }
        public Delivery Delivery { get; set; } = new Delivery();

        // Delivery update attributes

        public DeliveryStatus Status { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string UpdateDescription { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Notes { get; set; }

        public string UpdatedBy { get; set; } = "System";
        public int? UpdatedByUserID { get; set; }
        public AppUser? UpdatedByUser { get; set; }
    }
}

