﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SCMWebApp.Shared.Models
{
    public partial class SCMWebAppDatabaseContext : DbContext
    {
        public SCMWebAppDatabaseContext()
        {
        }

        public SCMWebAppDatabaseContext(DbContextOptions<SCMWebAppDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<BannerType> BannerType { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Programme> Programme { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StudentApplication> StudentApplication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasOne(d => d.BannerType)
                    .WithMany(p => p.Banner)
                    .HasForeignKey(d => d.BannerTypeId)
                    .HasConstraintName("FK_Banner_ToBannerType");

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.Banner)
                    .HasForeignKey(d => d.ProgrammeId)
                    .HasConstraintName("FK_Banner_Programme");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Staff_ToPosition");

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.ProgrammeId)
                    .HasConstraintName("FK_Staff_ToProgramme");
            });

            modelBuilder.Entity<StudentApplication>(entity =>
            {
                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.StudentApplication)
                    .HasForeignKey(d => d.ProgrammeId)
                    .HasConstraintName("FK_StudentApplication_ToProgramme");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}