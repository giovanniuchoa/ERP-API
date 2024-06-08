using CarQuery__Test.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarQuery__Test.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Client)
                .WithMany()
                .HasForeignKey(s => s.Fk_IdClient)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Seller)
                .WithMany()
                .HasForeignKey(s => s.Fk_IdSeller)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany()
                .HasForeignKey(s => s.Fk_IdCar)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
