using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace.IMS.Domain.ViewModels.Audits
{
    public class AuditLogViewModel
    {
        public int AuditLogID { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Action { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public int EntityID { get; set; }

        public string TimeStampDisplay { get; set; } = string.Empty;
        public string StatusDisplay { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;
    }
}

/* for mapping 
var vm = new AuditLogViewModel
{
    AuditLogID = dto.AuditLogID,
    Username = dto.Username,
    Action = dto.Action,
    EntityType = dto.EntityType,
    EntityID = dto.EntityID,
    TimestampDisplay = dto.Timestamp.ToLocalTime().ToString("MMM dd, yyyy hh:mm tt"),
    StatusDisplay = dto.Success ? "Success" : "Failed",
    Source = dto.Source ?? "N/A"
};
*/
