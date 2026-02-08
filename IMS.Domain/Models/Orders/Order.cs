using IMS.Domain.Enums;
using IMS.Domain.Models.Financial;
using IMS.Domain.Models.Users.Identity;
using Microsoft.EntityFrameworkCore;

namespace IMS.Domain.Models.Orders
{
    public class Order
    {
        // Primary key
        public int? OrderID { get; set; }

        // Foreign key
        public int? ReceiptID { get; set; }

        // Navigation key
        public AppUser? Recipient { get; set; }
        public ICollection<OrderMealProduct>? OrderItems { get; set; } = new List<OrderMealProduct>();

        // Order attributes
        public decimal OrderTotalAmount
        {
            get { return OrderItems?.Sum(item => item.ItemPrice) ?? 0; }
        }

        // Order dated details
        public DateTime OrderDate { get; } = DateTime.Now;
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }

        // Order status details
        public DeliveryStatus DeliveryType { get; set; }
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;

        // Order logistics details
        public string? Address { get; set; }
        public string? TrackingNumber { get; set; }
        public string? CustomerNotes { get; set; }
        public string? SpecialInstructions { get; set; }
    }

}
