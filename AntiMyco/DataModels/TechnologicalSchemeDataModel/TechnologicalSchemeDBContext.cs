using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
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
        public virtual DbSet<EquipmentInvolvedInOperation> EquipmentInvolvedInOperations { get; set; } = null!;
        public virtual DbSet<EquipmentParameter> EquipmentParameters { get; set; } = null!;
        public virtual DbSet<MaterialBalance> MaterialBalances { get; set; } = null!;
        public virtual DbSet<Operation> Operations { get; set; } = null!;
        public virtual DbSet<Parameter> Parameters { get; set; } = null!;
        public virtual DbSet<ParameterValue> ParameterValues { get; set; } = null!;
        public virtual DbSet<ProcessParameter> ProcessParameters { get; set; } = null!;
        public virtual DbSet<ProductionScheme> ProductionSchemes { get; set; } = null!;
        public virtual DbSet<Stage> Stages { get; set; } = null!;
        public virtual DbSet<Substance> Substances { get; set; } = null!;
        public virtual DbSet<SubstanceClass> SubstanceClasses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TechnologicalSchemeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("Action");

                entity.HasIndex(e => e.IdNextAction, "IX_Relationship16");

                entity.Property(e => e.IdNextAction).HasColumnName("Id next action");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.IdNextActionNavigation)
                    .WithMany(p => p.InverseIdNextActionNavigation)
                    .HasForeignKey(d => d.IdNextAction)
                    .HasConstraintName("Relationship16");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.AdditionalSpecifications)
                    .HasColumnType("text")
                    .HasColumnName("Additional specifications");

                entity.Property(e => e.Name).HasColumnType("text");
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

            modelBuilder.Entity<MaterialBalance>(entity =>
            {
                entity.HasKey(e => new { e.IdSubstance, e.IdClass, e.IdStage });

                entity.ToTable("Material balance");

                entity.Property(e => e.IdSubstance).HasColumnName("Id substance");

                entity.Property(e => e.IdClass).HasColumnName("Id class");

                entity.Property(e => e.IdStage).HasColumnName("Id Stage");

                entity.Property(e => e.ChanfeG).HasColumnName("Chanfe, g");

                entity.Property(e => e.ChangeMl).HasColumnName("Change, ml");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.MaterialBalances)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship25");

                entity.HasOne(d => d.IdStageNavigation)
                    .WithMany(p => p.MaterialBalances)
                    .HasForeignKey(d => d.IdStage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship26");

                entity.HasOne(d => d.IdSubstanceNavigation)
                    .WithMany(p => p.MaterialBalances)
                    .HasForeignKey(d => d.IdSubstance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship20");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("Operation");

                entity.HasIndex(e => e.IdNextOperation, "IX_Relationship14");

                entity.HasIndex(e => e.IdStartAction, "IX_Relationship17");

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
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
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

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Unit).HasColumnType("text");
            });

            modelBuilder.Entity<ProductionScheme>(entity =>
            {
                entity.ToTable("Production scheme");

                entity.HasIndex(e => e.IdStartSstage, "IX_Relationship9");

                entity.Property(e => e.IdStartSstage).HasColumnName("Id start sstage");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.IdStartSstageNavigation)
                    .WithMany(p => p.ProductionSchemes)
                    .HasForeignKey(d => d.IdStartSstage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship9");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("Stage");

                entity.HasIndex(e => e.IdStartOperation, "IX_Relationship7");

                entity.HasIndex(e => e.IdNextStage, "IX_Relationship8");

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

            modelBuilder.Entity<Substance>(entity =>
            {
                entity.ToTable("Substance");

                entity.Property(e => e.Indicator).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<SubstanceClass>(entity =>
            {
                entity.ToTable("Substance class");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
