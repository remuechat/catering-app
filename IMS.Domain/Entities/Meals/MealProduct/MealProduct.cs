using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Entities.Financial.Promos;
using IMS.Domain.Entities.Users.Identity;

namespace IMS.Domain.Entities.Meals.MealProduct;


/// <summary>
/// This is a composite of [MealProductItem]s that a user can create.
/// This is also a base class implementation of CATERING MEAL table.
/// The difference is that catering meals are on a separate table,
/// with RBAC (operators can only make catering meals) and 
/// users can custom make their own meal product packs.
/// 
/// The computed properties below aren't logged because it will be
/// constantly validated throughout the frontend and backend per transaction.
/// </summary>
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
    public AppUser? Owner { get; set; }

    public ICollection<MealProductItem> MealProducts { get; set; } = [];

    public Promo? Promo { get; set; }

    [Required]
    [StringLength(200)]
    public string ProductName { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? ProductDescription { get; set; }


    // Computed properties for pricing
    [NotMapped]
    public decimal ProductBasePrice => MealProducts.Sum(item => item.ItemPrice);

    [NotMapped]
    public decimal DiscountAmount => ProductBasePrice - FinalPrice;

    [NotMapped]
    public decimal FinalPrice => Promo?.ApplyDiscount(ProductBasePrice) ?? ProductBasePrice;
}
