

namespace IMS.Domain.Models.Users.Identity
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Role { get; set; } = string.Empty;

        // Summary counts for the Profile/Dashboard
        public int MealProductCount { get; set; }
        public int OrderCount { get; set; }
        public int ReceiptCount { get; set; }
    }
    
}