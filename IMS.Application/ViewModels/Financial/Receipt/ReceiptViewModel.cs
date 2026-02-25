using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Application.ViewModels.Financial.Receipt
{
    public class ReceiptViewModel : BaseViewModel
    {
        private string _status = string.Empty;
        private string _totalDisplay = string.Empty;
        private string _customerName = string.Empty;

        public int ReceiptID { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public string FormattedDate { get; set; } = string.Empty;

        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public string TotalDisplay
        {
            get => _totalDisplay;
            set => SetProperty(ref _totalDisplay, value);
        }

        // Details-only fields (for the pop-up/form)
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
