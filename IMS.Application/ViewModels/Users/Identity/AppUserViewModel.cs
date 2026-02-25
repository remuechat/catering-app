using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Application.ViewModels.Users.Identity
{
    public class AppUserViewModel : BaseViewModel
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _role = string.Empty;

        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string FullName => $"{FirstName} {LastName}";

        public string Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        // Stats for the UI cards
        public string MealSummary { get; set; } = "0 Meals Created";
        public string OrderSummary { get; set; } = "0 Orders Placed";
    }
}
