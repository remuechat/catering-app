using IMS.Application.ViewModels.Meals;
using IMS.Domain.Entities.Meals.MealProduct;
using IMS.Service.DTOs.Meals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IMS.Application.Mappers
{
    //dto -> viewmodel
    public static class MealProductViewMapper
    {
        public static MealProductViewModel MapToViewModel(MealProductDto dto)
        {
            if (dto == null) return new MealProductViewModel();
            var vm = new MealProductViewModel
            {
                MealProductID = dto.MealProductID,
                ProductName = dto.ProductName,
                ProductDescription = dto.ProductDescription ?? "",
                FormattedBasePrice = "₱" + dto.ProductBasePrice.ToString("N2"),
                FormattedDiscount = "₱" + dto.DiscountAmount.ToString("N2"),
                FormattedFinalPrice = "₱" + dto.FinalPrice.ToString("N2"),
                Status = "Active"
            };

            var items = dto.MealProductItems.Select(i => new MealProductItemViewModel
            {
                MealName = i.MealName,
                Quantity = i.Quantity,
                FormattedItemPrice = "₱" + i.ItemPrice.ToString("N2"),
                RequestDescription = i.RequestDescription ?? ""
            });

            vm.Items = new ObservableCollection<MealProductItemViewModel>(items);
            return vm;
        }
    }
}
