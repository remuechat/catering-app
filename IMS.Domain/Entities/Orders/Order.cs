using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Enums;
using IMS.Domain.Models.Financial;
using IMS.Domain.Models.Financial.Receipt;
using IMS.Domain.Models.Users.Identity;
using Microsoft.EntityFrameworkCore;

namespace IMS.Domain.Models.Orders
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderID { get; set; }

        [ForeignKey(nameof(AcknowledgementReceipt))]
        public int? ReceiptID { get; set; }

        // Navigation key
        public AppUser? Recipient { get; set; }
        public AcknowledgementReceipt? Receipt { get; set; }
        public ICollection<OrderMealProduct>? OrderItems { get; set; } = [];

        [NotMapped]
        public decimal OrderTotalAmount
        {
            get { return OrderItems?.Sum(item => item.ItemPrice) ?? 0; }
        }

        // Order dated details
        public DateTime OrderDate { get; } = DateTime.Now;

        [Display(Name = "Estimated Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EstimatedDeliveryDate { get; set; }

        [Display(Name = "Actual Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ActualDeliveryDate { get; set; }

        // Order status details
        public DeliveryStatus DeliveryType { get; set; } = DeliveryStatus.OnCart;

        public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;

        // Order logistics details
        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string? Address { get; set; }

        [StringLength(50, ErrorMessage = "Tracking number cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "Tracking number can only contain uppercase letters, numbers, and hyphens")]
        public string? TrackingNumber { get; set; }

        [StringLength(500, ErrorMessage = "Customer notes cannot exceed 500 characters")]
        [DataType(DataType.MultilineText)]
        public string? CustomerNotes { get; set; }

        [StringLength(300, ErrorMessage = "Special instructions cannot exceed 300 characters")]
        [DataType(DataType.MultilineText)]
        public string? SpecialInstructions { get; set; }
    }

}
