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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLog>().HasKey(x => new { x.OrderId, x.LogId });
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });

            #region data seed 
            modelBuilder.Entity<FileModel>().HasData(
                 new FileModel
                 {
                     Id = 1,
                     Path = "/images/glasses.jpg"
                 },
                 new FileModel
                 {
                     Id = 2,
                     Path = "/images/headphones.jpg"
                 },
                 new FileModel
                 {
                     Id = 3,
                     Path = "/images/pepsi.jpg"
                 },
                 new FileModel
                 {
                     Id = 4,
                     Path = "/images/watch.jpg"
                 },
                 new FileModel
                 {
                     Id = 5,
                     Path = "/images/capcake.jpg"
                 },
                 new FileModel
                 {
                     Id = 6,
                     Path = "/images/cola.jpg"
                 },
                 new FileModel
                 {
                     Id = 7,
                     Path = "/images/packet.jpg"
                 },
                 new FileModel
                 {
                     Id = 8,
                     Path = "/images/parfume.jpg"
                 },
                 new FileModel
                 {
                     Id = 9,
                     Path = "/images/soda.jpg"
                 },
                 new FileModel
                 {
                     Id = 10,
                     Path = "/images/soda2.jpg"
                 });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Очки",
                    Price = 1000,
                    ImageId = 1,

                },
                new Product
                {
                    Id = 2,
                    Name = "Наушники",
                    Price = 3500,
                    ImageId = 2,

                },
                new Product
                {
                    Id = 3,
                    Name = "Pepsi-Cole",
                    Price = 350,
                    ImageId = 3,

                },
                new Product
                {
                    Id = 4,
                    Name = "Очки",
                    Price = 5000,
                    ImageId = 4,
                },
                new Product
                {
                    Id = 5,
                    Name = "Кекс",
                    Price = 250,
                    ImageId = 5,
                },
                new Product
                {
                    Id = 6,
                    Name = "Кола",
                    Price = 300,
                    ImageId = 6,
                },
                new Product
                {
                    Id = 7,
                    Name = "Кофе",
                    Price = 750,
                    ImageId = 7,
                },
                new Product
                {
                    Id = 8,
                    Name = "Духи",
                    Price = 15000,
                    ImageId = 8,
                },
                new Product
                {
                    Id = 9,
                    Name = "Напиток",
                    Price = 500,
                    ImageId = 9,
                },
                new Product
                {
                    Id = 10,
                    Name = "Candy Dry",
                    Price = 400,
                    ImageId = 10,
                });
            #endregion
        }
    }
}
