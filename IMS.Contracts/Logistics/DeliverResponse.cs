using System;
using System.Collections.Generic;
using System.Text;
using IMS.Domain.Entities.Logistics;
using IMS.Domain.Enums;
using IMS.Domain.Models.Orders;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Contracts.Logistics;

public class Delivery
{
    // Primary key
    public int DeliveryID { get; set; }

    // Foreign and navigation keys
    public ICollection<LogisticsUpdate> DeliveryUpdates { get; set; } = [];
    public Guid OrderID { get; set; }
    public Order Order { get; set; } = new();
    public int? DeliveryPersonnelID { get; set; }
    public AppUser? DeliveryPersonnel { get; set; }
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? EstimatedDeliveryDate { get; set; }
    public DateTime? ActualPickupDate { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }
    public string DeliveryAddress { get; set; } = string.Empty;
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? CustomerEmail { get; set; }
    public string? TrackingNumber { get; set; }
    public decimal ShippingCost { get; set; }
    public string? ShippingMethod { get; set; }
    public string? CarrierName { get; set; }
    public string? SpecialInstructions { get; set; }
    public string? DeliveryNotes { get; set; }
    public string? ProofOfDelivery { get; set; }
    public decimal? CurrentLatitude { get; set; }
    public decimal? CurrentLongitude { get; set; }
    public DateTime? LastLocationUpdate { get; set; }

    public bool SignatureRequired { get; set; } = true;
    public string? ReceivedBy { get; set; }
    public DateTime? ReceivedAt { get; set; }

}
