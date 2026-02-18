using IMS.Domain.Entities.Audits;
using IMS.Domain.Entities.Financial;
using IMS.Domain.Entities.Financial.AcknowledgementReceipts;
using IMS.Domain.Entities.Financial.Promos;
using IMS.Domain.Entities.Logistics;
using IMS.Domain.Entities.Meals.MealItems;
using IMS.Domain.Entities.Meals.MealProduct;
using IMS.Domain.Entities.Orders;
using IMS.Domain.Entities.Users.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMS.Service.Data;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    // CHORE: Add password security, hashing and database salting later on.

    // Basic tracking
    // TECH DEBT: Make sure that tracking is logged throughout the entire controllers.
    public DbSet<AuditLog> AuditLogs { get; set; }

    // MEALS and related entities
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealTag> MealTags { get; set; }
    public DbSet<MealProduct> UserMealProducts { get; set; }
    // Add this later?
    // public DbSet<MealProduct> CateringProducts { get; set; }

    // ORDERING meals and related entities
    public DbSet<Order> Orders { get; set; }

    // FINANCIAL and related entities
    public DbSet<Promo> Promos { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<AcknowledgementReceipt> AcknowledgementReceipts { get; set; }

    // LOGISTICS and related entities
    public DbSet<LogisticsUpdate> LogisticsUpdates { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CHORE: Add modelBuilder.Entity configurations 
        //        for your entities here or in separate methods
        //        to boost performance later on. 
        //        Not needed for now though.
    }
}