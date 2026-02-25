using System;
using System.Globalization;

namespace IMS.Application.ViewModels.Financial.Promos
{
    public class PromoViewModel : BaseViewModel
    {
        private string _status = string.Empty;
        private decimal _discountValue;
        private decimal _minimumOrder;
        private int _usedCount;
        private int? _usageLimit;
        private DateTime _startDate;
        private DateTime _endDate;


        public int PromoID { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //decimal for calculations, to string (formatting) in UI
        public decimal DiscountValue
        {
            get => _discountValue;
            set
            {
                if (SetProperty(ref _discountValue, value))
                    OnPropertyChanged(nameof(DiscountDisplay));
            }
        }

        public decimal MinimumOrder 
        {
            get => _minimumOrder;
            set
            {
                if (SetProperty(ref _minimumOrder, value))
                    OnPropertyChanged(nameof(MinimumOrderDisplay));
            }
        }
        
        //DateTime for logic, then format it for the View
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (SetProperty(ref _startDate, value))
                    OnPropertyChanged(nameof(ValidPeriod));
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (SetProperty(ref _endDate, value))
                    OnPropertyChanged(nameof(ValidPeriod));
            }
        }

        public int UsedCount
        {
            get => _usedCount;
            set
            {
                if (SetProperty(ref _usedCount, value))
                    OnPropertyChanged(nameof(UsageInfo));
            }
        }
        public int? UsageLimit
        {
            get => _usageLimit;
            set
            {
                if (SetProperty(ref _usageLimit, value))
                    OnPropertyChanged(nameof(UsageInfo));
            }
        }


        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value); 
        }


        //read-only helper prop for UI display
        public string ValidPeriod => $"{StartDate:MMM dd, yyyy} - {EndDate:MMM dd, yyyy}";

        public string DiscountDisplay => $"{DiscountValue:0.##}%";

        public string MinimumOrderDisplay => MinimumOrder > 0 ? MinimumOrder.ToString("C", new CultureInfo("en-PH")) : "None";
        public string UsageInfo => UsageLimit.HasValue ? $"{UsedCount} / {UsageLimit}" : "Unlimited";

    }
}
