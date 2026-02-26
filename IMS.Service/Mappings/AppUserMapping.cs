using IMS.Domain.Entities.Users.Identity;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Service.Mappings
{
    public static class AppUserMapping
    {
        //Entity -> DTO (Stripping sensitive Identity data)
        public static AppUserDto MapToDto(AppUser entity)
        {
            if (entity == null) return null!;

            return new AppUserDto
            {
                Id = entity.Id,
                Username = entity.UserName ?? string.Empty,
                Email = entity.Email ?? string.Empty,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Role = entity.AuthorizationType.ToString(),

                // Map the counts for lazy loading efficiency
                MealProductCount = entity.UserMealProducts?.Count ?? 0,
                OrderCount = entity.UserOrders?.Count ?? 0,
                ReceiptCount = entity.UserReceipts?.Count ?? 0
            };
        }
    }
}
