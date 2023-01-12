using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ColaProject.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Data
{
    public partial class BusStationSystemContext : DbContext
    {
        public BusStationSystemContext()
        {
        }

        public BusStationSystemContext(DbContextOptions<BusStationSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<KioskTypes> KioskTypes { get; set; }
        public virtual DbSet<Kiosks> Kiosks { get; set; }
        public virtual DbSet<KisokStatus> KisokStatus { get; set; }
        public virtual DbSet<Maintenance> Maintenance { get; set; }
        public virtual DbSet<MaintenanceType> MaintenanceType { get; set; }
        public virtual DbSet<Operators> Operators { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Streets> Streets { get; set; }
        public virtual DbSet<Supervisers> Supervisers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Visites> Visites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=APR-ICT-14;Database=BusStationSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KioskTypes>(entity =>
            {
                entity.HasKey(e => e.KioskTypeId)
                    .HasName("PK_Kiosk Types");
            });

            modelBuilder.Entity<Kiosks>(entity =>
            {
                entity.HasKey(e => e.KioskId)
                    .HasName("PK_KioskTable");

                entity.Property(e => e.KioskId).ValueGeneratedNever();

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.KiosksCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kiosks_Users");

                entity.HasOne(d => d.KioskStatus)
                    .WithMany(p => p.Kiosks)
                    .HasForeignKey(d => d.KioskStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kiosks_KisokStatus");

                entity.HasOne(d => d.KioskType)
                    .WithMany(p => p.Kiosks)
                    .HasForeignKey(d => d.KioskTypeId)
                    .HasConstraintName("FK_Kiosks_KioskTypes");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.Kiosks)
                    .HasForeignKey(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kiosks_Operators");

                entity.HasOne(d => d.Supervioser)
                    .WithMany(p => p.Kiosks)
                    .HasForeignKey(d => d.SupervioserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kiosks_Supervisers");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.KiosksUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kiosks_Users1");
            });

            modelBuilder.Entity<KisokStatus>(entity =>
            {
                entity.Property(e => e.StatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.HasKey(e => e.MaintenanceProcessId)
                    .HasName("PK_MaintenanceProcess");

                entity.Property(e => e.MaintenanceProcessId).ValueGeneratedNever();

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.Maintenance)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaintenanceProcess_maintenance");

                entity.HasOne(d => d.Visite)
                    .WithMany(p => p.Maintenance)
                    .HasForeignKey(d => d.VisiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaintenanceProcess_Visites");
            });

            modelBuilder.Entity<MaintenanceType>(entity =>
            {
                entity.Property(e => e.MaintenanceTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Operators>(entity =>
            {
                entity.HasKey(e => e.OperatorId)
                    .HasName("PK_OperatorTable");

                entity.Property(e => e.OperatorId).ValueGeneratedNever();

                entity.Property(e => e.Disablity).IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.OperatorsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operators_Users");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.OperatorsUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operators_Users1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Streets>(entity =>
            {
                entity.HasKey(e => e.StreetId)
                    .HasName("PK_Streets_1");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Streets_Areas");
            });

            modelBuilder.Entity<Supervisers>(entity =>
            {
                entity.Property(e => e.SuperviserId).ValueGeneratedNever();

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SupervisersCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supervisers_Users");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.SupervisersUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supervisers_Users1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            modelBuilder.Entity<Visites>(entity =>
            {
                entity.Property(e => e.VisiteId).ValueGeneratedNever();

                entity.HasOne(d => d.Kiosk)
                    .WithMany(p => p.Visites)
                    .HasForeignKey(d => d.KioskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visites_KioskTable");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.Visites)
                    .HasForeignKey(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visites_OperatorTable");

                entity.HasOne(d => d.Superviser)
                    .WithMany(p => p.Visites)
                    .HasForeignKey(d => d.SuperviserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visites_Supervisers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
