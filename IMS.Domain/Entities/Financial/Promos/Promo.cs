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
/// 
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
    [StringLength(500)]
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
    [CustomValidation(typeof(Promo), "ValidateFutureDates")]
    public DateTime ValidFrom { get; set; }

    [Required]
    [CustomValidation(typeof(Promo), "ValidateValidUntil")]
    public DateTime ValidUntil { get; set; }

    public bool IsActive { get; set; } = true;

    // HELPER FUNCTIONS
    public decimal ApplyDiscount(decimal amount)
    {
        return amount * DiscountPercentageValue;
    }

    // Custom validation method
    public static ValidationResult ValidateValidUntil(DateTime validUntil, ValidationContext context)
    {
        var instance = (Promo)context.ObjectInstance;
        if (validUntil <= instance.ValidFrom)
        {
            return new ValidationResult("Valid Until date must be after Valid From date");
        }
        return ValidationResult.Success!;
    }

    public static ValidationResult ValidateFutureDates(DateTime validFrom, ValidationContext context)
    {
        if (validFrom < DateTime.Today)
        {
            return new ValidationResult("Valid From date cannot be in the past");
        }
        return ValidationResult.Success!;
    }

}
