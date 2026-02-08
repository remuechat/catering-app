using System.Linq;
using System.Reflection;
using IMS.Domain.Enums;
using IMS.Domain.Models.Audits;
using IMS.Domain.Models.Financial;
using IMS.Domain.Models.Financial.Promos;
using IMS.Domain.Models.Meals.MealItems;
using IMS.Domain.Models.Meals.MealProduct;
using IMS.Domain.Models.Users.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace IMS.Service.Data;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSets for your custom entities
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealTag> MealTags { get; set; }
    public DbSet<MealProduct> MealProducts { get; set; }
    public DbSet<Promo> Promos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CHORE: Add modelBuilder.Entity configurations 
        //        for your entities here or in separate methods
        //        to boost performance later on. 
        //        Not needed for now though.
    }
}