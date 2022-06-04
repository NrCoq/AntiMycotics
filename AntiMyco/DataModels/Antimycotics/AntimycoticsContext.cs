using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntiMyco.DataModels.Antimycotics
{
    public partial class AntimycoticsContext : DbContext
    {
        public AntimycoticsContext()
        {
        }

        public AntimycoticsContext(DbContextOptions<AntimycoticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Antimycotic> Antimycotics { get; set; } = null!;
        public virtual DbSet<Disease> Diseases { get; set; } = null!;
        public virtual DbSet<Precursor> Precursors { get; set; } = null!;
        public virtual DbSet<SideEffect> SideEffects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-F6MEBGR;Database=Antimycotics;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Antimycotic>(entity =>
            {
                entity.ToTable("Antimycotic");

                entity.HasIndex(e => e.PrecursorId, "IX_Relationship1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PrecursorId).HasColumnName("precursor_id");

                entity.Property(e => e.Properties)
                    .HasColumnType("text")
                    .HasColumnName("properties");

                entity.Property(e => e.Smiles)
                    .HasColumnType("text")
                    .HasColumnName("SMILES");

                entity.Property(e => e.Toxicity)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("toxicity");

                entity.HasOne(d => d.Precursor)
                    .WithMany(p => p.Antimycotics)
                    .HasForeignKey(d => d.PrecursorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Extends");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasMany(d => d.Antimycotics)
                    .WithMany(p => p.Diseases)
                    .UsingEntity<Dictionary<string, object>>(
                        "DiseasesList",
                        l => l.HasOne<Antimycotic>().WithMany().HasForeignKey("AntimycoticId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship3"),
                        r => r.HasOne<Disease>().WithMany().HasForeignKey("DiseasesId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship2"),
                        j =>
                        {
                            j.HasKey("DiseasesId", "AntimycoticId");

                            j.ToTable("DiseasesList");

                            j.IndexerProperty<int>("DiseasesId").HasColumnName("diseases_id");

                            j.IndexerProperty<int>("AntimycoticId").HasColumnName("antimycotic_id");
                        });
            });

            modelBuilder.Entity<Precursor>(entity =>
            {
                entity.ToTable("Precursor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Smiles)
                    .HasColumnType("text")
                    .HasColumnName("SMILES");
            });

            modelBuilder.Entity<SideEffect>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.HasMany(d => d.Antimycotics)
                    .WithMany(p => p.Effects)
                    .UsingEntity<Dictionary<string, object>>(
                        "SideEffectsList",
                        l => l.HasOne<Antimycotic>().WithMany().HasForeignKey("AntimycoticId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship5"),
                        r => r.HasOne<SideEffect>().WithMany().HasForeignKey("EffectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship4"),
                        j =>
                        {
                            j.HasKey("EffectId", "AntimycoticId");

                            j.ToTable("SideEffectsList");

                            j.IndexerProperty<int>("EffectId").HasColumnName("effect_id");

                            j.IndexerProperty<int>("AntimycoticId").HasColumnName("antimycotic_id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
