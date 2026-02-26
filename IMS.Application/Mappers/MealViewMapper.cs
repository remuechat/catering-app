
using IMS.Application.ViewModels.Meals;
using IMS.Service.DTOs.Meals;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Application.Mappers
{
    public static class MealViewMapper
    {
        public static MealViewModel MapToViewModel(MealSummaryDto dto)
        {
            return new MealViewModel
            {
                MealID = dto.MealID,
                MealName = dto.MealName,
                ImageUrl = dto.ImageUrl,
                PriceDisplay = "P" + dto.MealPrice.ToString("N2"),
                StockStatus = dto.StockQuantity > 0
                ? $"{dto.StockQuantity} In Stock" : "Out of Stock"
            };
        }

        public static MealViewModel MapToViewModel(MealDetailsDto dto)
        {
            var vm = MapToViewModel((MealSummaryDto)dto); ;

            vm.Description = dto.Description ?? "No description available.";
            vm.TagNames = dto.Tags.Select(t => t.Name).ToList();

            return vm;
        }
    }
}
