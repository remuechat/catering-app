
using IMS.Service.DTOs.Logistics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IMS.Application.ViewModels.Logistics
{
    public class DeliveryViewModel : BaseViewModel
    {
        private int _deliveryId;
        private string _orderId = string.Empty;
        private string _trackingNumber = "N/A";
        private string _status = string.Empty;
        private string _formattedCost = "₱0.00";
        private string _estimatedArrival = "TBD";
        private string _deliveryAddress = string.Empty;
        private ObservableCollection<DeliveryUpdateViewModel> _updateHistory = new();

        public int DeliveryID { get => _deliveryId; set => SetProperty(ref _deliveryId, value); }
        public string OrderID { get => _orderId; set => SetProperty(ref _orderId, value); }
        public string TrackingNumber { get => _trackingNumber; set => SetProperty(ref _trackingNumber, value); }
        public string Status { get => _status; set => SetProperty(ref _status, value); }
        public string FormattedCost { get => _formattedCost; set => SetProperty(ref _formattedCost, value); }
        public string EstimatedArrival { get => _estimatedArrival; set => SetProperty(ref _estimatedArrival, value); }
        public string DeliveryAddress { get => _deliveryAddress; set => SetProperty(ref _deliveryAddress, value); }

        public ObservableCollection<DeliveryUpdateViewModel> UpdateHistory
        {
            get => _updateHistory;
            set => SetProperty(ref _updateHistory, value);
        }
    }

    public class DeliveryUpdateViewModel : BaseViewModel
    {
        private string _status = string.Empty;
        private string _updateDate = string.Empty;
        private string _location = string.Empty;
        private string _description = string.Empty;

        public string Status { get => _status; set => SetProperty(ref _status, value); }
        public string UpdateDate { get => _updateDate; set => SetProperty(ref _updateDate, value); }
        public string Location { get => _location; set => SetProperty(ref _location, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
    }
}
