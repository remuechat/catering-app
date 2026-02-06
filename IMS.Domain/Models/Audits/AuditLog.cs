using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Domain.Models.Users.Identity;

namespace IMS.Domain.Models.Audits
{
    public class AuditLog
    {
        public int AuditLogID { get; set; }

        // Who performed the action
        public int? UserID { get; set; }
        public string Username { get; set; } = string.Empty;

        // What action was performed
        public string Action { get; set; } = string.Empty; // "CREATE", "UPDATE", "DELETE"
        public string EntityType { get; set; } = string.Empty; // "Order", "Meal", "User"
        public int EntityID { get; set; } // ID of the affected entity

        // When it happened
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Change details
        public string? OldValues { get; set; } // JSON serialized previous state
        public string? NewValues { get; set; } // JSON serialized new state
        public string? Changes { get; set; } // Specific field changes

        // Additional context
        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? Source { get; set; } // "Web", "API", "Mobile"

        // For failed actions
        public bool Success { get; set; } = true;
        public string? ErrorMessage { get; set; }
    }
}
