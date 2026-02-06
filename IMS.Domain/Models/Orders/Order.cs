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
        // Customer & delivery information
        public Guid OrderID { get; } = Guid.NewGuid();
        public int UserID { get; set; }
        public DateTime OrderDate { get; } = DateTime.Now;
        public Receipt? Receipt { get; set; }
        public DeliveryStatus DeliveryType { get; set; }
        public string? Address { get; set; }

        // Package details
        public List<OrderItem> OrderItems { get; set; } = new();

        // Suggested additions:
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string? TrackingNumber { get; set; }
        public decimal ShippingCost { get; set; }
        public string? CustomerNotes { get; set; }
        public string? SpecialInstructions { get; set; }
        public AppUser? Recipient { get; set; }
        public List<DeliveryUpdate> DeliveryHistory { get; set; } = new();
    }

}
