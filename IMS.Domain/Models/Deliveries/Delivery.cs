using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;
using IMS.Domain.Models.Orders;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Domain.Models.Deliveries
{
    public class Delivery
    {
        public int DeliveryID { get; set; }

        // Foreign key to Order
        public Guid OrderID { get; set; }
        public Order Order { get; set; } = new();

        // Delivery personnel information
        public int? DeliveryPersonnelID { get; set; }
        public AppUser? DeliveryPersonnel { get; set; }

        // Delivery status and timing
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualPickupDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }

        // Delivery address details
        public string DeliveryAddress { get; set; } = string.Empty;
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }

        // Delivery tracking and logistics
        public string? TrackingNumber { get; set; }
        public decimal ShippingCost { get; set; }
        public string? ShippingMethod { get; set; }
        public string? CarrierName { get; set; }

        // Delivery instructions and notes
        public string? SpecialInstructions { get; set; }
        public string? DeliveryNotes { get; set; }
        public string? ProofOfDelivery { get; set; } // URL or path to delivery proof

        // Geolocation tracking (optional)
        public decimal? CurrentLatitude { get; set; }
        public decimal? CurrentLongitude { get; set; }
        public DateTime? LastLocationUpdate { get; set; }

        // Delivery validation
        public bool SignatureRequired { get; set; } = true;
        public string? ReceivedBy { get; set; }
        public DateTime? ReceivedAt { get; set; }

        // Navigation properties
        public List<DeliveryUpdate> DeliveryUpdates { get; set; } = new();
    }
}
