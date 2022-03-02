#nullable disable
using Microsoft.EntityFrameworkCore;
using Einstein.Models;

namespace Einstein.Data
{
    public partial class EinsteinContext : DbContext
    {
        public EinsteinContext()
        {
        }

        public EinsteinContext(DbContextOptions<EinsteinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Medical> Medicals { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Schedule).HasColumnType("datetime");
            });

            modelBuilder.Entity<Medical>(entity =>
            {
                entity.ToTable("Medical");

                entity.Property(e => e.Birth).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Specialty)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Birth).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}