using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Service.DTOs.Logistics
{
    public class DeliveryUpdateDto
    {
        public int DeliveryUpdateID {  get; set; }
        public int DeliveryID { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; }
        public string UpdateDescription { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public string UpdatedByUserName { get; set; } = string.Empty;
    }

    public class DeliverySummaryDto
    {
        public int DeliveryID { get; set; }
        public Guid OrderID { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? TrackingNumber { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public DateTime? EstimatedDeliveryDate { get; set; }
    }

    public class DeliveryDetailsDto : DeliverySummaryDto
    {
        public decimal ShippingCost { get; set; }
        public string? ShippingMethod { get; set; }
        public string? CarrierName { get; set; }
        public string? SpecialInstructions { get; set; }
        public List<DeliveryUpdateDto> Updates { get; set; } = new();
    }
}
