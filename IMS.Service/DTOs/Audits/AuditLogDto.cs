using System;

namespace IMS.Service.DTOs.Audits;
    public class AuditLogDto
    {
        public int AuditLogID { get; set; }

        public int? UserID { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Action { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public int EntityID { get; set; }

        public DateTime Timestamp { get; set; }

        public string? IPAddress { get; set; }
        public string? Source { get; set; }

        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }   

    }

    //for view details button if meron
    public class AuditLogDetailsDto
    {
        public int AuditLogID { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Action { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public int EntityID { get; set; }

        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? Changes { get; set; }

        public DateTime Timestamp { get; set; }

        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? Source { get; set; }

        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
