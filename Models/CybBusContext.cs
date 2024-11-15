using System;
using System.Collections.Generic;
using Assignment_BusApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignment_BusApplication.Models;

public partial class CybBusContext : Assignment_BusApplicationContext
{
    

    public CybBusContext(DbContextOptions<CybBusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<BusRoute> BusRoutes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE488226B26BA");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951AED6AF77A14");

            entity.ToTable(tb => tb.HasTrigger("NumberOfBookedSeats"));

            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.PassengerName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SeatsBooked)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.BusId).HasName("PK__Buses__6A0F60B56C242958");

            entity.ToTable(tb => tb.HasTrigger("DeleteBuses"));

            entity.Property(e => e.BusNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DriverName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BusRoute>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__BusRoute__80979B4D27A41C4B");

            entity.ToTable(tb => tb.HasTrigger("SetSeatAvailability"));

            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.EndLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SeatAvailability).HasDefaultValue(0);
            entity.Property(e => e.StartLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Customer__1788CC4CD624400F");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
