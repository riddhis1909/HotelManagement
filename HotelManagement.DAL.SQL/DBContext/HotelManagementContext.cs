using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DAL.SQL.DBContext;

public partial class HotelManagementContext : DbContext
{
    public HotelManagementContext()
    {
    }

    public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<tblCountry> tblCountries { get; set; }

    public virtual DbSet<tblRole> tblRoles { get; set; }

    public virtual DbSet<tblRoomStatus> tblRoomStatuses { get; set; }

    public virtual DbSet<tblState> tblStates { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblCountry>(entity =>
        {
            entity.HasKey(e => e.CountryID);

            entity.ToTable("tblCountry");

            entity.Property(e => e.Capital)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.ISO2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ISO3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PhoneCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<tblRole>(entity =>
        {
            entity.HasKey(e => e.RoleID);

            entity.ToTable("tblRole");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<tblRoomStatus>(entity =>
        {
            entity.HasKey(e => e.RoomStatusID);

            entity.ToTable("tblRoomStatus");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.RoomStatusIcon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoomStatusName)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<tblState>(entity =>
        {
            entity.HasKey(e => e.StateID);

            entity.ToTable("tblState");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.tblStates)
                .HasForeignKey(d => d.CountryID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblState_tblCountry");
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.UserID);

            entity.ToTable("tblUser");

            entity.HasIndex(e => e.EmailID, "UQ_tblUser_EmailID").IsUnique();

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.tblUsers)
                .HasForeignKey(d => d.RoleID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblUser_tblRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
