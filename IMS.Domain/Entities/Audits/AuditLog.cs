using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Entities.Users.Identity;
using IMS.Domain.Enums;

namespace IMS.Domain.Entities.Audits;

/// <summary>
/// This is a generic and simple editing log for ALL of our entities.
/// </summary>

public class AuditLog
{
    // Primary Key
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuditLogID { get; set; }

    // Foreign key/navigation keys
    [ForeignKey("User")]
    public int? UserID { get; set; }
    public AppUser? User { get; set; }

    // If you want to know what actions were performed and to which,
    [Required]
    public AuditActionType AuditActionType { get; set; }

    [Required]
    [StringLength(100)]
    public string EntityType { get; set; } = string.Empty;

    [Required]
    public int EntityID { get; set; }

    // If you want to see when it happened,
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    // If you want to see the delta,
    [Column(TypeName = "nvarchar(max)")]
    public string? OldValues { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? NewValues { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? Changes { get; set; }

    // If you want to track the source,
    [StringLength(45)]
    public string? IPAddress { get; set; }

    [StringLength(500)]
    public string? UserAgent { get; set; }

    [StringLength(50)]
    public string? Source { get; set; }

    // If failed,
    [Required]
    public bool Success { get; set; } = true;

    [Column(TypeName = "nvarchar(max)")]
    public string? ErrorMessage { get; set; }
}
