using IMS.Presentation.DTOs.Audits;
using System;
using System.Collections.Generic;
using System.Text;
using IMS.Presentation.ViewModels.Audits;

namespace IMS.Presentation.Mappers
{
    public static class AuditLogViewMapper
    {
        // 1. mapping the summary DTO for the main list
        public static AuditLogViewModel MapToViewModel(AuditLogDto dto)
        {
            if (dto == null) return new AuditLogViewModel();

            return new AuditLogViewModel
            {
                AuditLogID = dto.AuditLogID,
                Username = dto.Username,
                Action = dto.Action,
                EntityType = dto.EntityType,
                EntityID = dto.EntityID,
                TimestampDisplay = dto.Timestamp.ToLocalTime().ToString("MMM dd, yyyy hh:mm tt"), // Formatting for PH local time
                StatusDisplay = dto.Success ? "Success" : "Failed", 
                Source = dto.Source ?? "N/A"
            };
        }

        //mapping the details DTO for the pop-up
        public static AuditLogDetailsViewModel MapToDetailsViewModel(AuditLogDetailsDto dto)
        {
            if (dto == null) return new AuditLogDetailsViewModel();

            return new AuditLogDetailsViewModel
            {
                AuditLogID = dto.AuditLogID,
                Username = dto.Username,
                Action = dto.Action,
                EntityType = dto.EntityType,
                EntityID = dto.EntityID,
                OldValues = dto.OldValues,
                NewValues = dto.NewValues,
                Changes = dto.Changes,
                TimestampDisplay = dto.Timestamp.ToLocalTime().ToString("MMM dd, yyyy hh:mm tt"),
                StatusDisplay = dto.Success ? "Success" : "Failed",
                ErrorMessage = dto.ErrorMessage,
                IPAddress = dto.IPAddress,
                UserAgent = dto.UserAgent
            };
        }
    }
}
