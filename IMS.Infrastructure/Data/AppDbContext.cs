using IMS.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IMS.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
             
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=AppDb;Integrated Security=True; " +
                "TrustServerCertificate=True;");
            optionsBuilder.ConfigureWarnings(static w =>
            w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
