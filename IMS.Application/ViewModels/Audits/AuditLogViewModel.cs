using System;

namespace IMS.Application.ViewModels.Audits
{

    public class AuditLogViewModel : BaseViewModel
    {
        //FOR TABLELIST
        private string _username = string.Empty;
        private string _action = string.Empty;
        private string _timestampDisplay = string.Empty;
        private string _statusDisplay = string.Empty;

        public int AuditLogID { get; set; }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string Action
        {
            get => _action;
            set => SetProperty(ref _action, value);
        }

        public string? EntityType { get; set; } = string.Empty;
        public int EntityID { get; set; }

        public string TimestampDisplay
        {
            get => _timestampDisplay;
            set => SetProperty(ref _timestampDisplay, value);
        }

        public string StatusDisplay
        {
            get => _statusDisplay;
            set => SetProperty(ref _statusDisplay, value);
        }

        public string? Source { get; set; }
    }

    // FOR VIEW DETAILS
    public class AuditLogDetailsViewModel : BaseViewModel
    {
        // Copying properties from DetailsDto for the pop-up
        public int AuditLogID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public int EntityID { get; set; }

        // heavy properties
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? Changes { get; set; }

        public string TimestampDisplay { get; set; } = string.Empty;
        public string StatusDisplay { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }
    }



}