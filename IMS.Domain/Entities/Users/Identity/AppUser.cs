using IMS.Domain.Entities.Financial.AcknowledgementReceipts;
using IMS.Domain.Entities.Meals.MealProduct;
using IMS.Domain.Entities.Orders;
using Microsoft.AspNetCore.Identity;

namespace IMS.Domain.Entities.Users.Identity;

/// <summary>
/// Represents an application user with extended navigation properties for managing user-specific data relationships.
/// Extends IdentityUser with integer primary key and provides navigation collections for:
/// - User's meal productors (or rather, meal packs) that they've made themselves [UserMealProducts] 
/// - User's cart, organized by each order (UserOrders)
/// - User's receipt acknowledgements (UserReceipts)
/// TECH DEBT: Make sure to lazy load all of this using DTOs later on.
/// </summary>

public class AppUser : IdentityUser<int>
{
    public virtual ICollection<MealProduct> UserMealProducts { get; set; } = [];
    public virtual ICollection<Order> UserOrders { get; set; } = [];
    public virtual ICollection<AcknowledgementReceipt> UserReceipts { get; set; } = [];
}