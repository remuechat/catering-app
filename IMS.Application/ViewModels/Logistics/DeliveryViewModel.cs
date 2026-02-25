
using IMS.Service.DTOs.Logistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Application.ViewModels.Logistics
{
    public class DeliveryViewModel : BaseViewModel
    {
        public int DeliveryID { get; set; }
        public string OrderID { get; set; } = string.Empty;
        public string TrackingNumber { get; set; } = "N/A";
        public string Status { get; set; } = string.Empty;
        public string FormattedCost { get; set; } = string.Empty;
        public string EstimatedArrival { get; set; } = string.Empty;

        //for detail view
        public List<DeliveryUpdateDto> UpdateHistory { get; set; } = new();
    }
}
