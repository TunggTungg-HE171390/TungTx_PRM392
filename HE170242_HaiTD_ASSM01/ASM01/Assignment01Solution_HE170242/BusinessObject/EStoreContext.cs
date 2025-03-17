using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class EStoreContext : DbContext
    {
        public EStoreContext() { }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<Member>().HasData(
                new Member { MemberId = 1, Email = "test1@gmail.com", CompanyName = "FSoft", City = "Ha Noi", Country = "Vietnam", Passsword = "123456" },
                new Member { MemberId = 2, Email = "test2@gmail.com", CompanyName = "FA", City = "Hue", Country = "Vietnam", Passsword = "123456" },
                new Member { MemberId = 3, Email = "test3@gmail.com", CompanyName = "TPBank", City = "Da nang", Country = "Vietnam", Passsword = "123456" },
                new Member { MemberId = 4, Email = "test4@gmail.com", CompanyName = "VPBank", City = "HCM", Country = "Vietnam", Passsword = "123456" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Thuc an" },
                new Category { CategoryId = 2, CategoryName = "vong co" },
                new Category { CategoryId = 3, CategoryName = "do choi" },
                new Category { CategoryId = 4, CategoryName = "quan ao" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Thức ăn cho chó", Weight = 2.5m, UnitPrice = 150000, UnitInStock = 50 },
                new Product { ProductId = 2, CategoryId = 2, ProductName = "Vòng cổ thông minh", Weight = 0.2m, UnitPrice = 300000, UnitInStock = 30 },
                new Product { ProductId = 3, CategoryId = 3, ProductName = "Bóng đồ chơi", Weight = 0.5m, UnitPrice = 100000, UnitInStock = 40 },
                new Product { ProductId = 4, CategoryId = 4, ProductName = "Áo cho chó", Weight = 0.3m, UnitPrice = 200000, UnitInStock = 20 }
);

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, MemberId = 1, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(5), ShippedDate = DateTime.Now.AddDays(2), Freight = 50000 },
                new Order { OrderId = 2, MemberId = 2, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(4), ShippedDate = DateTime.Now.AddDays(1), Freight = 45000 },
                new Order { OrderId = 3, MemberId = 3, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(6), ShippedDate = DateTime.Now.AddDays(3), Freight = 55000 }
            );

            modelBuilder.Entity<OrderDetails>().HasData(
                new OrderDetails { OrderId = 1, ProductId = 1, UnitPrice = 150000, Quantity = 2, Discount = 0 },
                new OrderDetails { OrderId = 1, ProductId = 2, UnitPrice = 300000, Quantity = 1, Discount = 10 },
                new OrderDetails { OrderId = 2, ProductId = 3, UnitPrice = 100000, Quantity = 3, Discount = 5 },
                new OrderDetails { OrderId = 3, ProductId = 4, UnitPrice = 200000, Quantity = 1, Discount = 0 },
                new OrderDetails { OrderId = 3, ProductId = 1, UnitPrice = 150000, Quantity = 1, Discount = 0 }
            );
        }
    }
}
