using DrinkStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.DAL
{
    public class DrinkStoreContext : IdentityDbContext<User>
    {
        public DrinkStoreContext(DbContextOptions<DrinkStoreContext> options)
            : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PackSize> PackSizes { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=kandula.db.elephantsql.com;Database=jqjxpuud;Username=jqjxpuud;Password=k7EK5Es2_t5DFVBejpzBbTOE3BuKoB5o");
        
        
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

            
            
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Ásványvíz" },
                new Category { Id = 2, Name = "Bor" },
                new Category { Id = 3, Name = "Cider" },
                new Category { Id = 4, Name = "Citromlé" },
                new Category { Id = 5, Name = "Pezsgő" },
                new Category { Id = 6, Name = "Sör" }
            );

            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory { Id = 1, CategoryId = 2, Name = "Gyümölcs bor" },
                new Subcategory { Id = 2, CategoryId = 2, Name = "Házi bor" },
                new Subcategory { Id = 3, CategoryId = 2, Name = "Külföldi bor" },
                new Subcategory { Id = 4, CategoryId = 2, Name = "Magyar bor" },
                new Subcategory { Id = 5, CategoryId = 2, Name = "Rendezvény bor" },
                new Subcategory { Id = 6, CategoryId = 6, Name = "Borsodi Sörgyár Kft." },
                new Subcategory { Id = 7, CategoryId = 6, Name = "Brewdog" }
            );

            modelBuilder.Entity<PackSize>().HasData(
                new PackSize { Id = 1, Quanitity = 1.50, Unit = "l" },
                new PackSize { Id = 2, Quanitity = 0.75, Unit = "l" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Szekszárdi Vörös Cuvée", UnitPrice = 902, CategoryId = 2, SubCategoryId = 4, PackSizeId = 1 },
                new Product { Id = 2, Name = "Birtok Fehér", UnitPrice = 736, CategoryId = 2, SubCategoryId = 4, PackSizeId = 2 }
            );

            modelBuilder.Entity<Product>().Property(b => b.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Category>().Property(b => b.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Subcategory>().Property(b => b.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Order>().Property(b => b.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<PackSize>().Property(b => b.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<ProductOrder>().Property(b => b.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<UserOrder>().Property(b => b.Id).UseIdentityAlwaysColumn();
        }
    }
}
