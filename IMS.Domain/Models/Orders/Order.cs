using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;
using IMS.Domain.Models.Deliveries;
using IMS.Domain.Models.Financial;
using IMS.Domain.Models.Packages;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Domain.Models.Orders
{
    public class Order
    {
        // Primary key
        public Guid OrderID { get; } = Guid.NewGuid();

        // Navigation/foreign keys
        public int UserID { get; set; }
        public AppUser? Recipient { get; set; }
        public Receipt? Receipt { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
        public List<DeliveryUpdate> DeliveryHistory { get; set; } = new();

        // Order dated details
        public DateTime OrderDate { get; } = DateTime.Now;
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }

        // Order status details
        public DeliveryStatus DeliveryType { get; set; }
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;

        // Order logistics details
        public string? Address { get; set; }
        public string? TrackingNumber { get; set; }
        public string? CustomerNotes { get; set; }
        public string? SpecialInstructions { get; set; }

    }

}
