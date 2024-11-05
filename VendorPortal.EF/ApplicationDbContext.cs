using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VendorPortal.Core;

namespace VendorPortal.EF;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<OrdersFlag> OrdersFlags { get; set; }

    public virtual DbSet<OrdersXsc> OrdersXscs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=192.168.0.173,34300;Database=ETI_MarketPlace;User ID=sa;Password=Dataadmin2010;integrated security=false;TrustServerCertificate=True;Connection Timeout=3600");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC07336F76FB");

            entity.ToTable("OrderStatus", tb => tb.HasTrigger("AfterUpdateOrderStatus"));

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeliveryMethod)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderAwb)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("OrderAWB");
            entity.Property(e => e.OrderRef)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OrderStatus1)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("OrderStatus");
        });

        modelBuilder.Entity<OrdersFlag>(entity =>
        {
            entity.ToTable("OrdersFlag");

            entity.HasIndex(e => e.FlagId, "IX_OrdersFlag_flagId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.FlagId).HasColumnName("flagId");
            entity.Property(e => e.FlagStatus).HasColumnName("flagStatus");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(20)
                .HasColumnName("orderNumber");
        });

        modelBuilder.Entity<OrdersXsc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OrdersXSC");

            entity.Property(e => e.Awb)
                .HasMaxLength(150)
                .HasColumnName("AWB");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(250)
                .HasColumnName("Customer Address");
            entity.Property(e => e.CustomerInfo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Customer Info");
            entity.Property(e => e.CustomerMobile)
                .HasMaxLength(255)
                .HasColumnName("Customer Mobile");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(4000)
                .HasColumnName("Customer Name");
            entity.Property(e => e.DeliveryInfo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Delivery Info");
            entity.Property(e => e.District).HasMaxLength(255);
            entity.Property(e => e.Driver)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DxCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("DX Created Date");
            entity.Property(e => e.DxInvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("DX Invoice Date");
            entity.Property(e => e.DxStatus)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("DX Status");
            entity.Property(e => e.FleetInfo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Fleet Info");
            entity.Property(e => e.OrderDates)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Order Dates");
            entity.Property(e => e.OrderInfo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Order info");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(20)
                .HasColumnName("Order Number");
            entity.Property(e => e.OrderRef)
                .HasMaxLength(60)
                .HasColumnName("Order Ref");
            entity.Property(e => e.OrderSource).HasMaxLength(250);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.ReleasedInfo)
                .HasMaxLength(199)
                .IsUnicode(false)
                .HasColumnName("Released INFO");
            entity.Property(e => e.ScAwbStatus)
                .HasMaxLength(200)
                .HasColumnName("SC AWB Status");
            entity.Property(e => e.ScAwbStatusDate)
                .HasMaxLength(30)
                .HasColumnName("SC AWB status Date");
            entity.Property(e => e.ScCreatedDate)
                .HasMaxLength(30)
                .HasColumnName("SC Created Date");
            entity.Property(e => e.ScDriverComment).HasColumnName("SC Driver Comment");
            entity.Property(e => e.ScDriverDeliverProduct)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("SC Driver Deliver Product");
            entity.Property(e => e.ScDriverMobile).HasColumnName("SC Driver Mobile");
            entity.Property(e => e.ScDriverName)
                .HasMaxLength(255)
                .HasColumnName("SC Driver Name");
            entity.Property(e => e.ScDriverUploadedDocument)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("SC Driver Uploaded Document");
            entity.Property(e => e.ScExpectedDeliver)
                .HasColumnType("datetime")
                .HasColumnName("SC Expected Deliver");
            entity.Property(e => e.ScInternalStatus)
                .HasMaxLength(255)
                .HasColumnName("SC internal Status");
            entity.Property(e => e.ScPodAmount)
                .HasMaxLength(30)
                .HasColumnName("SC POD Amount");
            entity.Property(e => e.ScReleaseCreated)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("SC Release Created");
            entity.Property(e => e.ScReleaseDate)
                .HasMaxLength(30)
                .HasColumnName("SC Release Date");
            entity.Property(e => e.ScReleaseNo)
                .HasMaxLength(30)
                .HasColumnName("SC Release No");
            entity.Property(e => e.ScReleaseStatus)
                .HasMaxLength(50)
                .HasColumnName("SC Release status");
            entity.Property(e => e.ScShipmentCreated)
                .HasMaxLength(50)
                .HasColumnName("SC Shipment Created");
            entity.Property(e => e.ScShipmentNo)
                .HasMaxLength(30)
                .HasColumnName("SC Shipment No");
            entity.Property(e => e.ScTruckPalletNo)
                .HasMaxLength(100)
                .HasColumnName("SC Truck Pallet No");
            entity.Property(e => e.ShippingwayCustom)
                .HasMaxLength(75)
                .HasColumnName("SHIPPINGWAY_CUSTOM");
            entity.Property(e => e.Source)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.StatusInfo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Status Info");
            entity.Property(e => e.WarehouseInfo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Warehouse Info");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(100)
                .HasColumnName("Warehouse Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
