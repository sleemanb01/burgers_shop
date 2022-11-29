using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BurgersShop.Models
{
    public partial class BurgerShopContext : DbContext
    {
        public BurgerShopContext()
        {
            // this.Configuration.LazyLoadingEnabled = false;
            // this.LazyInitializer = false;
            // this.
        }

        public BurgerShopContext(DbContextOptions<BurgerShopContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Burger> Burgers { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Extra> Extras { get; set; } = null!;
        public virtual DbSet<FoodOrder> FoodOrders { get; set; } = null!;
        public virtual DbSet<OrderBurger> OrderBurgers { get; set; } = null!;
        public virtual DbSet<OrderExtra> OrderExtras { get; set; } = null!;
        public virtual DbSet<OrderSide> OrderSides { get; set; } = null!;
        public virtual DbSet<Side> Sides { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=BurgerShop;Trusted_Connection=False;password=1234;user=sa1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.HasIndex(e => e.BranchName, "UQ__Branch__838DF7F596946013")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .HasColumnName("branchName");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.HouseNum).HasColumnName("houseNum");

                entity.Property(e => e.OpeningHrs)
                    .HasMaxLength(50)
                    .HasColumnName("openingHrs");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Burger>(entity =>
            {
                entity.ToTable("Burger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.ImageFileName)
                    .HasMaxLength(50)
                    .HasColumnName("imageFileName");

                entity.Property(e => e.MealDescription)
                    .HasMaxLength(50)
                    .HasColumnName("mealDescription");

                entity.Property(e => e.MealName)
                    .HasMaxLength(50)
                    .HasColumnName("mealName");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bdate)
                    .HasColumnType("date")
                    .HasColumnName("bdate")
                    .HasDefaultValueSql("(CONVERT([date],getdate(),(105)))");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("lname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");
                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .HasColumnName("pass");
            });

            modelBuilder.Entity<Extra>(entity =>
            {
                entity.ToTable("Extra");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.ImageFileName)
                    .HasMaxLength(50)
                    .HasColumnName("imageFileName");

                entity.Property(e => e.MealDescription)
                    .HasMaxLength(50)
                    .HasColumnName("mealDescription");

                entity.Property(e => e.MealName)
                    .HasMaxLength(50)
                    .HasColumnName("mealName");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<FoodOrder>(entity =>
            {
                entity.ToTable("FoodOrder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate")
                    .HasDefaultValueSql("(CONVERT([date],getdate(),(105)))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.FoodOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__FoodOrder__custo__2E1BDC42");
            });

            modelBuilder.Entity<OrderBurger>(entity =>
            {
                entity.ToTable("OrderBurger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.HasOne(d => d.Burger)
                    .WithMany(p => p.OrderBurgers)
                    .HasForeignKey(d => d.BurgerId)
                    .HasConstraintName("FK__OrderBurg__Burge__33D4B598");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderBurgers)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderBurg__order__34C8D9D1");
            });

            modelBuilder.Entity<OrderExtra>(entity =>
            {
                entity.ToTable("OrderExtra");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderExtra1).HasColumnName("orderExtra");

                entity.HasOne(d => d.OrderBurger)
                    .WithMany(p => p.OrderExtras)
                    .HasForeignKey(d => d.OrderBurgerId)
                    .HasConstraintName("FK__OrderExtr__Order__38996AB5");

                entity.HasOne(d => d.OrderExtra1Navigation)
                    .WithMany(p => p.OrderExtras)
                    .HasForeignKey(d => d.OrderExtra1)
                    .HasConstraintName("FK__OrderExtr__order__37A5467C");
            });

            modelBuilder.Entity<OrderSide>(entity =>
            {
                entity.ToTable("OrderSide");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderSides)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderSide__order__3C69FB99");

                entity.HasOne(d => d.OrderSide1Navigation)
                    .WithMany(p => p.OrderSides)
                    .HasForeignKey(d => d.SideId)
                    .HasConstraintName("FK__OrderSide__order__3B75D760");
            });

            modelBuilder.Entity<Side>(entity =>
            {
                entity.ToTable("Side");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.ImageFileName)
                    .HasMaxLength(50)
                    .HasColumnName("imageFileName");

                entity.Property(e => e.MealDescription)
                    .HasMaxLength(50)
                    .HasColumnName("mealDescription");

                entity.Property(e => e.MealName)
                    .HasMaxLength(50)
                    .HasColumnName("mealName");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
