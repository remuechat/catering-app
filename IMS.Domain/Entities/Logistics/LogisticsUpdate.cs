using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Entities.Users.Identity;
using IMS.Domain.Enums;

namespace IMS.Domain.Entities.Logistics;

/// <summary>
/// This represents the updates that 
/// </summary>
public class LogisticsUpdate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeliveryUpdateID { get; set; }

    // Foreign and navigation keys
    [ForeignKey("Delivery")]
    public int DeliveryID { get; set; }
    public virtual Delivery Delivery { get; set; } = new Delivery();

    [ForeignKey("UpdatedByUser")]
    public int? UpdatedByUserID { get; set; }
    public virtual AppUser? UpdatedByUser { get; set; }

    // Delivery update attributes
    [Required]
    public DeliveryStatus Status { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime UpdateDate { get; set; } = DateTime.Now;

    [Required]
    [StringLength(500)]
    public string UpdateDescription { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Location { get; set; }

    [StringLength(1000)]
    public string? Notes { get; set; }

    [Required]
    [StringLength(100)]
    public string UpdatedBy { get; set; } = String.Empty;
}
