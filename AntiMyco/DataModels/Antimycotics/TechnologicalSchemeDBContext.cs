using System;
using System.Collections.Generic;
using AntiMyco.DataModels.TechnologicalSchemeDataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntiMyco.DataModels.Antimycotics
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

        public virtual DbSet<Equipment> Equipment { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-F6MEBGR;Database=TechnologicalSchemeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.AdditionalSpecifications)
                    .HasColumnType("text")
                    .HasColumnName("Additional specifications");

                entity.Property(e => e.Macro).HasColumnType("image");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
