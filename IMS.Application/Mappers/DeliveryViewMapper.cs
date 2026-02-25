
using IMS.Presentation.ViewModels.Logistics;
using IMS.Service.DTOs.Logistics;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace IMS.Application.Mappers
{
    public class DeliveryViewMapper
    {
        public static DeliveryViewModel MapToViewModel(DeliverySummaryDto dto)
        {
            return new DeliveryViewModel
            {
                DeliveryID = dto.DeliveryID,
                OrderID = dto.OrderID.ToString(),
                TrackingNumber = dto.TrackingNumber ?? "Pending",
                Status = dto.Status,
                EstimatedArrival = dto.EstimatedDeliveryDate?.ToString("MM dd, yyyy") ?? "TBD"
            };
        }

        public static DeliveryViewModel MapToViewModel(DeliveryDetailsDto dto)
        {
            var vm = MapToViewModel((DeliverySummaryDto)dto);
            vm.FormattedCost = "P" + dto.ShippingCost.ToString("N2");
            vm.UpdateHistory = dto.Updates;
            return vm;
        }
    }
}
