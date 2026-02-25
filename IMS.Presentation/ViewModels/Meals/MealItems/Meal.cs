
using System;

namespace IMS.Presentation.ViewModels.Meals.MealItem
{
    public class MealViewModel : BaseViewModel
    {
        private decimal _mealPrice;
        private decimal _discount;

        public decimal MealPrice
        {
            get => _mealPrice;
            set
            {
                if (SetProperty(ref _mealPrice, value))
                    OnPropertyChanged(nameof(FinalPrice)); //update finalprice whenever mealprice changes
            }
        }

        public decimal Discount
        {
            get => _discount;
            set
            {
                if (SetProperty(ref _discount, value))
                    OnPropertyChanged(nameof(FinalPrice)); //update finalprice whenever discount changes
            }
        }

        public decimal FinalPrice => MealPrice - Discount;
    }
}

