using System.Linq;
using IMS.Domain.Enums;
using IMS.Domain.Models.Audits;
using IMS.Domain.Models.Financial;
using IMS.Domain.Models.Meals;
using IMS.Domain.Models.Orders;
using IMS.Domain.Models.Packages;
using IMS.Domain.Models.Users.Identity;
using IMS.Domain.Models.Users.UserCart;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IMS.Service.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Admin modifiable data
        // System generated data for compliance
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        // Operator modifiable data
        // Access only for users
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealTag> MealTags { get; set; }
        public DbSet<ApplicablePromo> Promos { get; set; }
        public DbSet<CateringPackage> CateringPackages { get; set; }

        // User-submitted data
        public DbSet<UserCart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
