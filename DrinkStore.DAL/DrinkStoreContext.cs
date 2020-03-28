using DrinkStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.DAL
{
    public class DrinkStoreContext : DbContext
    {
        public DrinkStoreContext(DbContextOptions<DrinkStoreContext> options)
            : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PackSize> PackSizes { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                         .HasOne(p => p.Category)
                         .WithMany(c => c.Products)
                         .IsRequired()
                         .OnDelete(DeleteBehavior.NoAction);


             modelBuilder.Entity<Product>()
                         .HasOne(p => p.SubCategory)
                         .WithMany(c => c.Products)
                         .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
