using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Models.Financial.Promos;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Domain.Models.Meals.MealProduct;

public class MealProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MealProductID { get; set; }

    [ForeignKey(nameof(Owner))]
    public int OwnerID { get; set; }

    [ForeignKey(nameof(Promo))]
    public int? PromoID { get; set; }

    [Required]
    public AppUser Owner { get; set; } = null!;

    public ICollection<MealProductItem> MealProducts { get; set; } = [];

    public Promo? Promo { get; set; }

    [Required]
    [StringLength(200)]
    public string ProductName { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? ProductDescription { get; set; }

    [NotMapped]
    public decimal ProductBasePrice => MealProducts.Sum(item => item.ItemPrice);

    [NotMapped]
    public decimal DiscountAmount => ProductBasePrice - FinalPrice;

    [NotMapped]
    public decimal FinalPrice => Promo?.ApplyDiscount(ProductBasePrice) ?? ProductBasePrice;
}
