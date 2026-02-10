using System.Linq;
using System.Reflection;
using IMS.Domain.Enums;
using IMS.Domain.Models.Audits;
using IMS.Domain.Models.Financial;
using IMS.Domain.Models.Financial.Promos;
using IMS.Domain.Models.Financial.Receipt;
using IMS.Domain.Models.Meals.MealItems;
using IMS.Domain.Models.Meals.MealProduct;
using IMS.Domain.Models.Orders;
using IMS.Domain.Models.Users.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMS.Service.Data;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    // CHORE: Add password security, hashing and database salting later on.


    // MEALS and related entities
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealTag> MealTags { get; set; }
    public DbSet<MealProduct> MealProducts { get; set; }

    // ORDERING meals and related entities
    public DbSet<Order> Orders { get; set; }

    // FINANCIAL and related entities
    public DbSet<Promo> Promos { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<AcknowledgementReceipt> AcknowledgementReceipts { get; set; }

    // LOGISTICS and related entities
    // Add DBSet for delivery & event later on, if created

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CHORE: Add modelBuilder.Entity configurations 
        //        for your entities here or in separate methods
        //        to boost performance later on. 
        //        Not needed for now though.
    }
}