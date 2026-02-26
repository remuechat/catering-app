using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Application.ViewModels.Meals
{
    public class MealViewModel : BaseViewModel
    {
        public string _priceDisplay = string.Empty;
        public string _stockStatus = string.Empty;

        public int MealID { get; set; }
        public string MealName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public string PriceDisplay
        {
            get => _priceDisplay;
            set => SetProperty(ref _priceDisplay, value);

        }

        public string StockStatus
        {
            get => _stockStatus;
            set => SetProperty(ref _stockStatus, value);
        }

        //detail properties
        public string Description { get; set; } = string.Empty;
        public List<string> TagNames { get; set; } = new();
}
