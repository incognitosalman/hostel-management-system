using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hostel.Domain.Entities;

namespace Hostel.Infrastructure.Data
{
    public partial class HostelContext : DbContext
    {
        public HostelContext(DbContextOptions<HostelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Facility> Facilities { get; set; } = null!;
        public virtual DbSet<Floor> Floors { get; set; } = null!;
        public virtual DbSet<Domain.Entities.Hostel> Hostels { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>(entity =>
            {
                entity.Property(e => e.Charges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(15);

                entity.HasOne(d => d.Hostel)
                    .WithMany(p => p.Floors)
                    .HasForeignKey(d => d.HostelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Hostels");
            });

            modelBuilder.Entity<Domain.Entities.Hostel>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(350);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomNumber).HasMaxLength(15);

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.FloorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Floors");

                entity.HasMany(d => d.Facilities)
                    .WithMany(p => p.Rooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoomFacility",
                        l => l.HasOne<Facility>().WithMany().HasForeignKey("FacilityId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RoomFacilities_Facilities"),
                        r => r.HasOne<Room>().WithMany().HasForeignKey("RoomId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RoomFacilities_Rooms"),
                        j =>
                        {
                            j.HasKey("RoomId", "FacilityId");

                            j.ToTable("RoomFacilities");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
