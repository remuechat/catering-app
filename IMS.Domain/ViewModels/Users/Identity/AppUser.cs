using IMS.Domain.Models.Financial.Receipt;
using IMS.Domain.Models.Meals.MealProduct;
using IMS.Domain.Models.Orders;
using Microsoft.AspNetCore.Identity;

namespace IMS.Domain.Models.Users.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public virtual ICollection<MealProduct> UserMealProducts { get; set; } = [];
        public virtual ICollection<Order> UserOrders { get; set; } = [];
        public virtual ICollection<AcknowledgementReceipt> UserReceipts { get; set; } = [];
    }
}