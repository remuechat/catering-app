using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IMS.Application.ViewModels.Orders
{
    public class OrderViewModel : BaseViewModel
    {
        private string _deliveryStatus = string.Empty;
        private string _trackingNumber = "N/A";

        public Guid OrderID { get; set; }
        public string RecipientName { get; set; } = string.Empty;
        public string FormattedTotal { get; set; } = string.Empty;
        public string OrderDateLabel { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;

        public string DeliveryStatus
        {
            get => _deliveryStatus;
            set => SetProperty(ref _deliveryStatus, value);
        }

        public string TrackingNumber
        {
            get => _trackingNumber;
            set => SetProperty(ref _trackingNumber, value);
        }

        public ObservableCollection<OrderMealProductViewModel> Items { get; set; } = [];
    }

    public class OrderMealProductViewModel : BaseViewModel
    {
        private int _quantity;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }
        public string FormattedPrice { get; set; } = string.Empty;
        public string FormattedSubTotal { get; set; } = string.Empty;
    }
}
