using IMS.Presentation.DTOs.Audits;
using System;
using System.Collections.Generic;
using System.Text;
using IMS.Domain.Entities.Audits;

namespace IMS.Presentation.Mappings
{
    public static class AuditLogMapping
    {
        // mapping the raw Database Entity to the Summary DTO (for lists)
        public static AuditLogDto MapToDto(AuditLog entity)
        {
            if (entity == null) return new AuditLogDto();

            return new AuditLogDto
            {
                AuditLogID = entity.AuditLogID,
                UserID = entity.UserID,
                // using Username from the navigation property if it exists
                Username = entity.User?.UserName ?? "System",

                Action = entity.AuditActionType.ToString(),
                EntityType = entity.EntityType,
                EntityID = entity.EntityID,
                Timestamp = entity.Timestamp,

                IPAddress = entity.IPAddress,
                Source = entity.Source,
                Success = entity.Success,
                ErrorMessage = entity.ErrorMessage
            };
        }

        // Maps the raw Database Entity to the Details DTO (for the pop-up)
        public static AuditLogDetailsDto MapToDetailsDto(AuditLog entity)
        {
            if (entity == null) return new AuditLogDetailsDto();

            return new AuditLogDetailsDto
            {
                AuditLogID = entity.AuditLogID,
                Username = entity.User?.UserName ?? "System",
                Action = entity.AuditActionType.ToString(),
                EntityType = entity.EntityType,
                EntityID = entity.EntityID,

                // These are the "Heavy" fields that are only in the Details DTO
                OldValues = entity.OldValues,
                NewValues = entity.NewValues,
                Changes = entity.Changes,

                Timestamp = entity.Timestamp,
                IPAddress = entity.IPAddress,
                UserAgent = entity.UserAgent,
                Source = entity.Source,
                Success = entity.Success,
                ErrorMessage = entity.ErrorMessage
            };
        }
    }
}
