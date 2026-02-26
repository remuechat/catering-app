using IMS.Application.ViewModels.Users.Identity;
using IMS.Domain.Models.Users.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Application.Mappers
{
    public static class AppUserViewMapper
    {
        // DTO -> ViewModel (Formatting for the screen)
        public static AppUserViewModel MapToViewModel(AppUserDto dto)
        {
            if (dto == null) return new AppUserViewModel();

            return new AppUserViewModel
            {
                UserID = dto.Id,
                Username = dto.Username,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = dto.Role,
                MealSummary = $"{dto.MealProductCount} Meals Created",
                OrderSummary = $"{dto.OrderCount} Orders Placed"
            };
        }
    }
}
