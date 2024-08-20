

using BikeStores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Infrastructure
{
    public class BikeStoreDBContext : DbContext
    {
        public BikeStoreDBContext(DbContextOptions<BikeStoreDBContext> contextOptions) : base(contextOptions)
        {

        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(o => new { o.OrderId, o.ItemId });

            modelBuilder.Entity<Stock>()
                .HasKey(s => new { s.StoreId, s.ProductId });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Store)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Staff)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }

}
