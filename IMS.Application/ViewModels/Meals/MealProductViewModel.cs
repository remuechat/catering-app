using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IMS.Application.ViewModels.Meals
{
    public class MealProductViewModel : BaseViewModel
    {
        private string _productName = string.Empty;
        private string _status = "Active";
        public int MealProductID { get; set; }
        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value) ;
        }
        public string ProductDescription { get; set; } = string.Empty;

        //formatted for ui
        public string FormattedBasePrice { get; set; } = string.Empty;
        public string FormattedFinalPrice {  get; set; } = string.Empty;
        public string FormattedDiscount {  get; set; } = string.Empty;

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public ObservableCollection<MealProductItemViewModel> Items { get; set; } = new();
    }

    public class MealProductItemViewModel : BaseViewModel
    {
        private int _quantity;

        public string MealName { get; set; } = string.Empty;
        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public string FormattedItemPrice { get; set; } = string.Empty;
        public string RequestDescription {  get; set; } = string.Empty;
    }

}
