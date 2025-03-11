﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Enterprise.Manager.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Manager.DB.Infrastructure.DBContext.DBContext
{
    public partial class EnterpriseDbContext : DbContext
    {
        public EnterpriseDbContext(){}

        public EnterpriseDbContext(DbContextOptions<EnterpriseDbContext> options) : base(options){}

        public virtual DbSet<CompanyEntity> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EnterpriseManager;Persist Security Info=True;User ID=EnterpriseManager;Password=test");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyEntity>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Exchange)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Isin)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}