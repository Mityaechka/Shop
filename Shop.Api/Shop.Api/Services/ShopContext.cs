using Microsoft.EntityFrameworkCore;
using Shop.Api.Data;

namespace Shop.Api.Services
{
    public class ShopContext : DbContext
    {
        public DbSet<FileModel> Files { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInformation> OrderInformations { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<OrderLog> OrderLogs { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLog>().HasKey(x => new { x.OrderId, x.LogId });
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });
        }
    }
}
