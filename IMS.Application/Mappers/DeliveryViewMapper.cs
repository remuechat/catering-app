
using IMS.Application.ViewModels.Logistics;
using IMS.Service.DTOs.Logistics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Text;

namespace IMS.Application.Mappers
{
    public class DeliveryViewMapper
    {
        // Maps the basic list info
        public static DeliveryViewModel MapToViewModel(DeliverySummaryDto dto)
        {
            if (dto == null) return new DeliveryViewModel();

            return new DeliveryViewModel
            {
                DeliveryID = dto.DeliveryID,
                OrderID = dto.OrderID.ToString(),
                Status = dto.Status,
                TrackingNumber = dto.TrackingNumber ?? "N/A",
                DeliveryAddress = dto.DeliveryAddress ?? string.Empty,
                EstimatedArrival = dto.EstimatedDeliveryDate?.ToString("MMM dd, yyyy") ?? "TBD"
            };
        }

        // Maps the full details including cost and history
        public static DeliveryViewModel MapToViewModel(DeliveryDetailsDto dto)
        {
            // Re-use the summary mapping to avoid repeating code
            var vm = MapToViewModel((DeliverySummaryDto)dto);

            // Add detailed-specific fields
            vm.FormattedCost = "₱" + dto.ShippingCost.ToString("N2");

            if (dto.Updates != null && dto.Updates.Any())
            {
                var updateVMs = dto.Updates.Select(u => new DeliveryUpdateViewModel
                {
                    Status = u.Status,
                    UpdateDate = u.UpdateDate.ToString("g"), // General date/time pattern
                    Location = u.Location ?? "Unknown",
                    Description = u.UpdateDescription
                });

                vm.UpdateHistory = new ObservableCollection<DeliveryUpdateViewModel>(updateVMs);
            }

            return vm;
        }
    }
}
