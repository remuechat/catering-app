using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Interfaces;

public interface ILogisticsItem
{
    public DateTime CreatedDate { get; set; }
    public string DeliveryAddress { get; set; }
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
    public string? CurrentLocation { get; set; }
    public bool SignatureRequired { get; set; }
    public string? ReceivedBy { get; set; }
    public DateTime? LastLocationUpdate { get; set; }
    public DateTime? ReceivedAt { get; set; }
}
