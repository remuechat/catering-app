
namespace IMS.Service.DTOs.Meals
{
    public class MealProductDto
    {
        public int MealProductID { get; set; }
        public int OwnerID { get; set; }
        public int? PromoID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        public decimal ProductBasePrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public List<MealProductItemDto> MealProductItems { get; set; } = new();
    }

    public class MealProductItemDto
    {
        public int MealID { get; set; }
        public string MealName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public string? RequestDescription { get; set; }
    }
}
