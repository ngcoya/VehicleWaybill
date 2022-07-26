using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TritonExpress.Models;

#nullable disable

namespace TritonExpress.Data
{
    public partial class TritoExpressContext : DbContext
    {
        public TritoExpressContext()
        {
        }

        public TritoExpressContext(DbContextOptions<TritoExpressContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Waybill> Waybills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-DFASQ2GB;Database=TritoExpress;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.ArrivalDate).IsUnicode(false);

                entity.Property(e => e.BranchName).IsUnicode(false);

                entity.Property(e => e.DepartureDate).IsUnicode(false);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__Branch__VehicleI__2A4B4B5E");

                entity.HasOne(d => d.Waybill)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.WaybillId)
                    .HasConstraintName("FK__Branch__WaybillI__29572725");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Registration).IsUnicode(false);

                entity.Property(e => e.VehicleColor).IsUnicode(false);

                entity.Property(e => e.VehicleMake).IsUnicode(false);

                entity.Property(e => e.VehicleModel).IsUnicode(false);
            });

            modelBuilder.Entity<Waybill>(entity =>
            {
                entity.Property(e => e.ArrivalDate).IsUnicode(false);

                entity.Property(e => e.CurrentBranch).IsUnicode(false);

                entity.Property(e => e.DepartureDate).IsUnicode(false);

                entity.Property(e => e.Dimensions).IsUnicode(false);

                entity.Property(e => e.TotWeight).IsUnicode(false);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Waybills)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__Waybill__Vehicle__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
