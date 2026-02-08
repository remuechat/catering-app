using IMS.Domain.Models.Meals.MealProduct;
using Microsoft.EntityFrameworkCore;

namespace IMS.Domain.Models.Orders
{
    // Junction entity OWNED by Order
    [Owned]
    public class OrderMealProduct
    {       
        // Foreign keys
        public Guid OrderID { get; set; }
        public Guid MealProductID { get; set; }

        // Navigator keys
        public Order? Order { get; set; }
        public MealProduct? MealProduct { get; set; }

        // Order item attributes
        public int OrderQty { get; set; }
        public decimal ItemPrice {
            get {
                return MealProduct?.SubtotalPrice ?? 0;
            }
        }
        
    }
}
