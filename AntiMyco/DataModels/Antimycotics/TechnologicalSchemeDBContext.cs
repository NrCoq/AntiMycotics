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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TechnologicalSchemeDB;Trusted_Connection=True;");
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
