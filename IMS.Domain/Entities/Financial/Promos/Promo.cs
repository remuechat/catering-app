using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Domain.Entities.Financial.Promos;

/// <summary>
/// The operator generates the promos for their entire business.
/// Can be added to mealproducts (in case of catering packages).
/// Can be added to orders itself (in case you are giving sales to customers).
/// </summary>
public class Promo
{
    // Primary key
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PromoID { get; set; }

    // Promo attributes
    [Required]
    [StringLength(20)]
    [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Promo code can only contain uppercase letters and numbers")]
    public string Code { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 100.00, ErrorMessage = "Discount percentage must be between 0.01% and 100%")]
    public decimal DiscountPercentageValue { get; set; }

    [Range(0.01, 10000.00)]
    public decimal? MinimumOrderAmount { get; set; }

    [Range(1, 100000)]
    public int? UsageLimit { get; set; }

    [Range(0, 100000)]
    public int UsedCount { get; set; } = 0;

    [Required]
    public DateTime ValidFrom { get; set; }

    [Required]
    public DateTime ValidUntil { get; set; }

    [NotMapped]
    public int AvailableCount => UsageLimit.HasValue ? (UsageLimit.Value - UsedCount) : int.MaxValue;

    [NotMapped]
    public bool IsExpired => DateTime.Today > ValidUntil;

    [NotMapped]
    public bool IsDepleted => UsageLimit.HasValue && UsedCount >= UsageLimit.Value;

    [NotMapped]
    public bool IsActive => !IsExpired && !IsDepleted;

}
