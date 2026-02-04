using IMS.Domain.Models.Foods;
using IMS.Domain.Models.Packages;
using Microsoft.EntityFrameworkCore;

namespace IMS.Service.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Food> Food { get; set; }
        public DbSet<MealPackage> MealPackages { get; set; }
    }
}
