using IMS.Application.ViewModels.Orders;
using IMS.Service.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IMS.Application.Mappers
{
    public static class OrderViewMapper {
        // dto to viewmodel

        public static OrderViewModel MapToViewModel(OrderDto dto)
        {
            if (dto == null) return new OrderViewModel();
            var vm = new OrderViewModel
            {
                OrderID = dto.OrderID,
                RecipientName = dto.RecipientName,
                FormattedTotal = "₱" + dto.OrderTotalAmount.ToString("N2"),
                OrderDateLabel = dto.OrderDate.ToString("MMM dd, yyyy"),
                ShippingAddress = dto.Address ?? "No address provided",
                DeliveryStatus = dto.DeliveryStatus,
                TrackingNumber = string.IsNullOrEmpty(dto.TrackingNumber) ? "N/A" : dto.TrackingNumber
            };

            var items = dto.OrderItems.Select(i => new OrderMealProductViewModel
            {
                ProductName = i.MealProductName,
                Quantity = i.MealProductOrderQty,
                FormattedPrice = "₱" + i.ItemPrice.ToString("N2"),
                FormattedSubTotal = "₱" + i.SubTotal.ToString("N2")
            });

            vm.Items = new ObservableCollection<OrderMealProductViewModel>(items);
            return vm;
        }
    }   
}
