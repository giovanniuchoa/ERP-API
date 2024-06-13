using CarQuery__Test.Domain.Models;
using Microsoft.Data.SqlClient;
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


        public async Task<List<Sale>> GetSalesByAsync(
            DateTime? dthRegistroINI,
            DateTime? dthRegistroFIN,
            string? marcaCarro,
            int? idVendedor,
            decimal? precoINI,
            decimal? precoFIN)
        {
            var parameters = new[]
            {
                new SqlParameter("@dthRegistroINI", dthRegistroINI.HasValue ? (object)dthRegistroINI.Value : DBNull.Value),
                new SqlParameter("@dthRegistroFIN", dthRegistroFIN.HasValue ? (object)dthRegistroFIN.Value : DBNull.Value),
                new SqlParameter("@marcaCarro", string.IsNullOrEmpty(marcaCarro) ? DBNull.Value : (object)marcaCarro),
                new SqlParameter("@idVendedor", idVendedor.HasValue ? (object)idVendedor.Value : DBNull.Value),
                new SqlParameter("@precoINI", precoINI.HasValue ? (object)precoINI.Value : DBNull.Value),
                new SqlParameter("@precoFIN", precoFIN.HasValue ? (object)precoFIN.Value : DBNull.Value)
            };

            return await Sales.FromSqlRaw("EXEC sp_BuscaVendas @dthRegistroINI, @dthRegistroFIN, @marcaCarro, @idVendedor, @precoINI, @precoFIN", parameters)
                              .ToListAsync();

        }

    }
}
