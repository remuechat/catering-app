namespace IMS.Service.DTOs.Orders
{
    public class OrderDto
    {
        public Guid OrderID { get; set; }
        public int? ReceiptID { get; set; }
        public int? RecipientID { get; set; }
        public string RecipientName { get; set; } = string.Empty;
        public decimal OrderTotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public string DeliveryType { get; set; } = string.Empty;
        public string DeliveryStatus { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? TrackingNumber { get; set; }
        public string? CustomerNotes { get; set; }
        public string? SpecialInstructions { get; set; }

        public List<OrderMealProductDto> OrderItems { get; set; } = [];
    }

    public class OrderMealProductDto
    {
        public Guid MealProductID { get; set; }
        public string MealProductName { get; set; } = string.Empty;
        public decimal ItemPrice { get; set; }
        public int MealProductOrderQty { get; set; }
        public decimal SubTotal { get; set; }
    }
}
