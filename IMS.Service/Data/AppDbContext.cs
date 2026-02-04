using IMS.Domain.Models.Meals;
using IMS.Domain.Models.Orders;
using IMS.Domain.Models.Packages;
using Microsoft.EntityFrameworkCore;

namespace IMS.Service.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Meal> Food { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<CateringPackage> CateringPackages { get; set; }

        // UPDATE EACH RELATIONSHIP LATER WITH FLUENT API
    }
}
