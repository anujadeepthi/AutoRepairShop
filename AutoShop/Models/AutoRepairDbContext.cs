using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoShop.Models;

namespace AutoShop.Models;

public partial class AutoRepairDbContext : DbContext
{
    public AutoRepairDbContext()
    {
    }

    public AutoRepairDbContext(DbContextOptions<AutoRepairDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustVehicle> CustVehicles { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; } 

    public virtual DbSet<WorkOrder> WorkOrders { get; set; }

    public virtual DbSet<WorkOrderDetail> WorkOrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AutoRepairDb;Username=postgres;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustVehicle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cust_Vehicles");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Zip).HasColumnName("zip");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeName).HasColumnName("Employee_Name");
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.Property(e => e.Vin).HasColumnName("VIN");
            entity.Property(e => e.Cust_Id).HasColumnName("Cust_Id");
        });


        modelBuilder.Entity<WorkOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WorkOrders_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.IssueReported).HasColumnName("Issue_Reported");
            entity.Property(e => e.ServiceType).HasColumnName("Service_Type");
            entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");
        });

        modelBuilder.Entity<WorkOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WorkOrderDetails_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.WorkOrder_Id).HasColumnName("WorkOrder_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}