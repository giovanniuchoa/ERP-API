using CarQuery__Test.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarQuery__Test.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Reseller> Resellers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
