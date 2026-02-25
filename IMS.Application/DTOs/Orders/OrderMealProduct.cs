using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Models.Financial.Promos;
using IMS.Domain.Models.Meals.MealProduct;
using Microsoft.EntityFrameworkCore;

namespace IMS.Domain.Models.Orders
{
    // Junction entity OWNED by Order
    [Owned]
    public class OrderMealProduct
    {
        [ForeignKey(nameof(OrderID))]
        public Guid OrderID { get; set; }
        [ForeignKey(nameof(MealProductID))]
        public Guid MealProductID { get; set; }
        [ForeignKey(nameof(Promo))]
        public int? PromoID { get; set; }

        // Navigator keys
        public Order? Order { get; set; }
        public MealProduct? MealProduct { get; set; }
        public Promo? Promo { get; set; }

        // Order item attributes
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int MealProductOrderQty { get; set; }
        [NotMapped]
        public decimal ItemPrice {
            get {
                return MealProduct?.FinalPrice ?? 0;
            }
        }
        
    }
}
