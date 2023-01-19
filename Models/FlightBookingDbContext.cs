using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstApi2.Models;

public partial class FlightBookingDbContext : DbContext
{
    public FlightBookingDbContext()
    {
    }

    public FlightBookingDbContext(DbContextOptions<FlightBookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Contain> Contains { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Passenger1> Passenger1s { get; set; }

    public virtual DbSet<Passenger2> Passenger2s { get; set; }

    public virtual DbSet<Passenger3> Passenger3s { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Provide> Provides { get; set; }

    public virtual DbSet<Ticket1> Ticket1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=FlightBookingDB;TrustServerCertificate=Yes;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.ApName).HasName("PK__AIRPORT__8D7DB8040566C1C3");

            entity.ToTable("AIRPORT");

            entity.Property(e => e.ApName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AP_NAME");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("STATE");
        });

        modelBuilder.Entity<Contain>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__CONTAIN__C57755202A7181DB");

            entity.ToTable("CONTAIN");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("PID");
            entity.Property(e => e.Flightcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FLIGHTCODE");
            entity.Property(e => e.Passportno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PASSPORTNO");
            entity.Property(e => e.Ticketno).HasColumnName("TICKETNO");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Flightcode).HasName("PK__FLIGHT__5ECE451E5A0B91FD");

            entity.ToTable("FLIGHT");

            entity.Property(e => e.Flightcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FLIGHTCODE");
            entity.Property(e => e.Arrival)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ARRIVAL");
            entity.Property(e => e.Departure)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DEPARTURE");
            entity.Property(e => e.Destination)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("DESTINATION");
            entity.Property(e => e.Source)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("SOURCE");
        });

        modelBuilder.Entity<Passenger1>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__PASSENGE__C57755206504736C");

            entity.ToTable("PASSENGER1");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("PID");
            entity.Property(e => e.Passportno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PASSPORTNO");
        });

        modelBuilder.Entity<Passenger2>(entity =>
        {
            entity.HasKey(e => e.Passportno).HasName("PK__PASSENGE__9B008F7BB2134F4E");

            entity.ToTable("PASSENGER2");

            entity.Property(e => e.Passportno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PASSPORTNO");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FNAME");
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LNAME");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SEX");
        });

        modelBuilder.Entity<Passenger3>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__PASSENGE__C5775520B2C9CF42");

            entity.ToTable("PASSENGER3");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("PID");
            entity.Property(e => e.Flightcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FLIGHTCODE");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__PHONE__C57755206829D07B");

            entity.ToTable("PHONE");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("PID");
        });

        modelBuilder.Entity<Provide>(entity =>
        {
            entity.HasKey(e => e.Flightcode).HasName("PK__PROVIDES__5ECE451EEE611932");

            entity.ToTable("PROVIDES");

            entity.Property(e => e.Flightcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FLIGHTCODE");
            entity.Property(e => e.Ticketno).HasColumnName("TICKETNO");
        });

        modelBuilder.Entity<Ticket1>(entity =>
        {
            entity.HasKey(e => e.Ticketno).HasName("PK__TICKET1__19464693AB4A6887");

            entity.ToTable("TICKET1");

            entity.Property(e => e.Ticketno)
                .ValueGeneratedNever()
                .HasColumnName("TICKETNO");
            entity.Property(e => e.Class)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CLASS");
            entity.Property(e => e.DateOfBooking)
                .HasColumnType("date")
                .HasColumnName("DATE_OF_BOOKING");
            entity.Property(e => e.DateOfTravel)
                .HasColumnType("date")
                .HasColumnName("DATE_OF_TRAVEL");
            entity.Property(e => e.Destination)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("DESTINATION");
            entity.Property(e => e.Pid).HasColumnName("PID");
            entity.Property(e => e.Source)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("SOURCE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
