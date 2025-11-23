using System;
using System.Collections.Generic;
using AtividadeWeb1.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadeWeb1.Context;

public partial class MainContext : DbContext
{
    public MainContext()
    {
    }

    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; initial catalog=BelleCroissantLyonnais; Trusted_Connection=true; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.AverageOrderValue).HasMaxLength(255);
            entity.Property(e => e.Churned).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("FirstName ");
            entity.Property(e => e.Frequency)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender).HasMaxLength(255);
            entity.Property(e => e.JoinDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("LastName ");
            entity.Property(e => e.LastPurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.MembershipStatus).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PreferredCategory).HasMaxLength(255);
            entity.Property(e => e.TotalSpending).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("Order");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("TransactionId ");
            entity.Property(e => e.Channel)
                .HasMaxLength(255)
                .HasColumnName("Channel ");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerId ");
            entity.Property(e => e.DiscountAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DiscountAmount ");
            entity.Property(e => e.F11).HasMaxLength(255);
            entity.Property(e => e.F12).HasMaxLength(255);
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("OrderDate ");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("PaymentMethod ");
            entity.Property(e => e.PromotionId).HasColumnName("PromotionId ");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.StoreId).HasColumnName("StoreId ");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TotalAmount ");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Order_Customer");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("OrderItemId ");
            entity.Property(e => e.Price)
                .HasMaxLength(255)
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("ProductId ");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionId ");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderItem_Product");

            entity.HasOne(d => d.Transaction).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_OrderItem_Order");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.Active).HasMaxLength(255);
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Ingredients)
                .HasMaxLength(255)
                .HasColumnName("ingredients");
            entity.Property(e => e.IntroducedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.Seasonal).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
