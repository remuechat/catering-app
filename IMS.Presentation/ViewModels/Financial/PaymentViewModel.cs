using System;

namespace IMS.Domain.ViewModels.Financial
{
    public class PaymentViewModel : BaseViewModel
    {
        private string _paymentId = string.Empty;
        private int _receiptId;
        private string _paymentMethod = string.Empty;
        private string _paymentStatus = string.Empty;
        private string _timeStamp = string.Empty;
        private string _amount = string.Empty;
        private string _description = string.Empty;

        public string PaymentID
        {
            get => _paymentId;
            set => SetProperty(ref _paymentId, value);
        }

        // renamed from AcknowledgementRecieptID per mapping notes
        public int ReceiptID
        {
            get => _receiptId;
            set => SetProperty(ref _receiptId, value);
        }

        public string PaymentMethod
        {
            get => _paymentMethod;
            set => SetProperty(ref _paymentMethod, value);
        }

        public string PaymentStatus
        {
            get => _paymentStatus;
            set => SetProperty(ref _paymentStatus, value);
        }

        public string TimeStamp
        {
            get => _timeStamp;
            set => SetProperty(ref _timeStamp, value);
        }

        public string Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
    }
}
