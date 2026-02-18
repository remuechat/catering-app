using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Entities.Orders;
using IMS.Domain.Entities.Users.Identity;
using IMS.Domain.Enums;
using IMS.Domain.Interfaces;

namespace IMS.Domain.Entities.Logistics;

/// <summary>
/// A logistical option for the delivery of an order.
/// This assumes that after checking out, you expect the catering
/// package to be delivered to your doorstep.
/// </summary>

public class Delivery : ILogisticsItem
{
    // Primary key
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeliveryID { get; set; }

    // Foreign and navigation keys
    public ICollection<LogisticsUpdate> DeliveryUpdates { get; set; } = [];

    [Required]
    [ForeignKey("Order")]
    public Guid OrderID { get; set; }

    [Required]
    public Order Order { get; set; } = new();

    [ForeignKey("DeliveryPersonnel")]
    public int? DeliveryPersonnelID { get; set; }
    public AppUser? DeliveryPersonnel { get; set; }

    [Required]
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;

    // ILogistics implementation
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required]
    [StringLength(500)]
    public string DeliveryAddress { get; set; } = string.Empty;

    [StringLength(100)]
    public string? CustomerName { get; set; }

    [StringLength(20)]
    [Phone]
    public string? CustomerPhone { get; set; }

    [StringLength(255)]
    [EmailAddress]
    public string? CustomerEmail { get; set; }

    [StringLength(50)]
    public string? TrackingNumber { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999.99)]
    public decimal ShippingCost { get; set; }

    [StringLength(50)]
    public string? ShippingMethod { get; set; }

    [StringLength(100)]
    public string? CarrierName { get; set; }

    [StringLength(1000)]
    public string? SpecialInstructions { get; set; }

    [StringLength(2000)]
    public string? DeliveryNotes { get; set; }

    [StringLength(500)]
    public string? ProofOfDelivery { get; set; }

    [StringLength(500)]
    public string? CurrentLocation { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? LastLocationUpdate { get; set; }

    [Required]
    public bool SignatureRequired { get; set; } = true;

    [StringLength(100)]
    public string? ReceivedBy { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? ReceivedAt { get; set; }

    // Unique delivery implementation
    [Column(TypeName = "datetime2")]
    public DateTime? EstimatedDeliveryDate { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? ActualDeliveryDate { get; set; }
}