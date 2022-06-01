using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntiMyco.DataModels
{
    public partial class TechnologicalSchemeDBContext : DbContext
    {
        public TechnologicalSchemeDBContext()
        {
        }

        public TechnologicalSchemeDBContext(DbContextOptions<TechnologicalSchemeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<EquipmentInvolvedInAction> EquipmentInvolvedInActions { get; set; } = null!;
        public virtual DbSet<EquipmentInvolvedInOperation> EquipmentInvolvedInOperations { get; set; } = null!;
        public virtual DbSet<EquipmentInvolvedInStage> EquipmentInvolvedInStages { get; set; } = null!;
        public virtual DbSet<EquipmentParameter> EquipmentParameters { get; set; } = null!;
        public virtual DbSet<Operation> Operations { get; set; } = null!;
        public virtual DbSet<Parameter> Parameters { get; set; } = null!;
        public virtual DbSet<ParameterValue> ParameterValues { get; set; } = null!;
        public virtual DbSet<ProcessParameter> ProcessParameters { get; set; } = null!;
        public virtual DbSet<ProductionScheme> ProductionSchemes { get; set; } = null!;
        public virtual DbSet<RawMaterial> RawMaterials { get; set; } = null!;
        public virtual DbSet<Stage> Stages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=TechnologicalSchemeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("Action");

                entity.HasIndex(e => e.IdNextAction, "IX_Relationship16");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdNextAction).HasColumnName("Id next action");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.IdNextActionNavigation)
                    .WithMany(p => p.InverseIdNextActionNavigation)
                    .HasForeignKey(d => d.IdNextAction)
                    .HasConstraintName("Relationship16");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdditionalSpecifications)
                    .HasColumnType("text")
                    .HasColumnName("Additional specifications");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<EquipmentInvolvedInAction>(entity =>
            {
                entity.HasKey(e => new { e.IdEquipment, e.IdAction });

                entity.ToTable("Equipment involved in action");

                entity.Property(e => e.IdEquipment).HasColumnName("Id equipment");

                entity.Property(e => e.IdAction).HasColumnName("Id action");

                entity.HasOne(d => d.IdActionNavigation)
                    .WithMany(p => p.EquipmentInvolvedInActions)
                    .HasForeignKey(d => d.IdAction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship26");

                entity.HasOne(d => d.IdEquipmentNavigation)
                    .WithMany(p => p.EquipmentInvolvedInActions)
                    .HasForeignKey(d => d.IdEquipment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship25");
            });

            modelBuilder.Entity<EquipmentInvolvedInOperation>(entity =>
            {
                entity.HasKey(e => new { e.IdEquipment, e.IdOperation });

                entity.ToTable("Equipment involved in operation");

                entity.Property(e => e.IdEquipment).HasColumnName("Id equipment");

                entity.Property(e => e.IdOperation).HasColumnName("Id operation");

                entity.Property(e => e.NumberOfUnits).HasColumnName("Number of units");

                entity.HasOne(d => d.IdEquipmentNavigation)
                    .WithMany(p => p.EquipmentInvolvedInOperations)
                    .HasForeignKey(d => d.IdEquipment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship10");

                entity.HasOne(d => d.IdOperationNavigation)
                    .WithMany(p => p.EquipmentInvolvedInOperations)
                    .HasForeignKey(d => d.IdOperation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship15");
            });

            modelBuilder.Entity<EquipmentInvolvedInStage>(entity =>
            {
                entity.HasKey(e => new { e.IdEquipment, e.IdStage })
                    .HasName("PK_Involved equipment in stage");

                entity.ToTable("Equipment involved in stage");

                entity.Property(e => e.IdEquipment).HasColumnName("Id equipment");

                entity.Property(e => e.IdStage).HasColumnName("Id stage");

                entity.Property(e => e.NumberOfUnits).HasColumnName("Number of units");

                entity.HasOne(d => d.IdEquipmentNavigation)
                    .WithMany(p => p.EquipmentInvolvedInStages)
                    .HasForeignKey(d => d.IdEquipment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship20");

                entity.HasOne(d => d.IdStageNavigation)
                    .WithMany(p => p.EquipmentInvolvedInStages)
                    .HasForeignKey(d => d.IdStage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship21");
            });

            modelBuilder.Entity<EquipmentParameter>(entity =>
            {
                entity.HasKey(e => new { e.IdParameter, e.IdEquipment });

                entity.ToTable("Equipment parameters");

                entity.Property(e => e.IdParameter).HasColumnName("Id parameter");

                entity.Property(e => e.IdEquipment).HasColumnName("Id equipment");

                entity.HasOne(d => d.IdEquipmentNavigation)
                    .WithMany(p => p.EquipmentParameters)
                    .HasForeignKey(d => d.IdEquipment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship13");

                entity.HasOne(d => d.IdParameterNavigation)
                    .WithMany(p => p.EquipmentParameters)
                    .HasForeignKey(d => d.IdParameter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship12");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("Operation");

                entity.HasIndex(e => e.IdNextOperation, "IX_Relationship14");

                entity.HasIndex(e => e.IdStartAction, "IX_Relationship17");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdNextOperation).HasColumnName("Id next operation");

                entity.Property(e => e.IdStartAction).HasColumnName("Id start action");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.IdNextOperationNavigation)
                    .WithMany(p => p.InverseIdNextOperationNavigation)
                    .HasForeignKey(d => d.IdNextOperation)
                    .HasConstraintName("Relationship14");

                entity.HasOne(d => d.IdStartActionNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.IdStartAction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship17");

                entity.HasMany(d => d.IdRawMaterials)
                    .WithMany(p => p.IdOperations)
                    .UsingEntity<Dictionary<string, object>>(
                        "RawMaterialInvolvedInOperation",
                        l => l.HasOne<RawMaterial>().WithMany().HasForeignKey("IdRawMaterial").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship23"),
                        r => r.HasOne<Operation>().WithMany().HasForeignKey("IdOperation").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship22"),
                        j =>
                        {
                            j.HasKey("IdOperation", "IdRawMaterial");

                            j.ToTable("Raw material involved in operation");

                            j.IndexerProperty<int>("IdOperation").HasColumnName("Id operation");

                            j.IndexerProperty<int>("IdRawMaterial").HasColumnName("Id raw material");
                        });
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Unit).HasColumnType("text");
            });

            modelBuilder.Entity<ParameterValue>(entity =>
            {
                entity.HasKey(e => new { e.IdParameter, e.IdAction });

                entity.ToTable("Parameter values");

                entity.Property(e => e.IdParameter).HasColumnName("Id parameter");

                entity.Property(e => e.IdAction).HasColumnName("Id action");

                entity.Property(e => e.MaxValue).HasColumnName("Max value");

                entity.Property(e => e.MinValue).HasColumnName("Min value");

                entity.HasOne(d => d.IdActionNavigation)
                    .WithMany(p => p.ParameterValues)
                    .HasForeignKey(d => d.IdAction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship19");

                entity.HasOne(d => d.IdParameterNavigation)
                    .WithMany(p => p.ParameterValues)
                    .HasForeignKey(d => d.IdParameter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship18");
            });

            modelBuilder.Entity<ProcessParameter>(entity =>
            {
                entity.ToTable("Process parameter");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Unit).HasColumnType("text");
            });

            modelBuilder.Entity<ProductionScheme>(entity =>
            {
                entity.ToTable("Production scheme");

                entity.HasIndex(e => e.IdStartSstage, "IX_Relationship9");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DescriptionProperties)
                    .HasColumnType("text")
                    .HasColumnName("Description properties");

                entity.Property(e => e.IdStartSstage).HasColumnName("Id start sstage");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.PharmacologicalProperties)
                    .HasColumnType("text")
                    .HasColumnName("Pharmacological properties");

                entity.Property(e => e.ProductPurpose)
                    .HasColumnType("text")
                    .HasColumnName("Product purpose");

                entity.HasOne(d => d.IdStartSstageNavigation)
                    .WithMany(p => p.ProductionSchemes)
                    .HasForeignKey(d => d.IdStartSstage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship9");
            });

            modelBuilder.Entity<RawMaterial>(entity =>
            {
                entity.ToTable("Raw material");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IndicatorsForChecking)
                    .HasColumnType("text")
                    .HasColumnName("Indicators for checking");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.NameInNtd)
                    .HasColumnType("text")
                    .HasColumnName("Name in NTD");

                entity.Property(e => e.SortOrVendorCode)
                    .HasColumnType("text")
                    .HasColumnName("Sort or vendor code");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("Stage");

                entity.HasIndex(e => e.IdStartOperation, "IX_Relationship7");

                entity.HasIndex(e => e.IdNextStage, "IX_Relationship8");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdNextStage).HasColumnName("Id next stage");

                entity.Property(e => e.IdStartOperation).HasColumnName("Id start operation");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.IdNextStageNavigation)
                    .WithMany(p => p.InverseIdNextStageNavigation)
                    .HasForeignKey(d => d.IdNextStage)
                    .HasConstraintName("Relationship8");

                entity.HasOne(d => d.IdStartOperationNavigation)
                    .WithMany(p => p.Stages)
                    .HasForeignKey(d => d.IdStartOperation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
