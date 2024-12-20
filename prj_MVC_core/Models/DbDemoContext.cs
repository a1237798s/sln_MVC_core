using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prj_MVC_core.Models;

public partial class DbdemoContext : DbContext
{
    public DbdemoContext()
    {
    }

    public DbdemoContext(DbContextOptions<DbdemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TCustomer> TCustomers { get; set; }

    public virtual DbSet<TPhoto> TPhotos { get; set; }

    public virtual DbSet<Tcomment> Tcomments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Data Source=.;Initial Catalog=DBdemo;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TCustomer>(entity =>
        {
            entity.HasKey(e => e.Fid);

            entity.ToTable("tCustomers");

            entity.Property(e => e.Fid).HasColumnName("fid");
            entity.Property(e => e.FAddress)
                .HasMaxLength(50)
                .HasColumnName("fAddress");
            entity.Property(e => e.FEmail)
                .HasMaxLength(50)
                .HasColumnName("fEmail");
            entity.Property(e => e.FName)
                .HasMaxLength(50)
                .HasColumnName("fName");
            entity.Property(e => e.FPassword)
                .HasMaxLength(50)
                .HasColumnName("fPassword");
            entity.Property(e => e.FPhone)
                .HasMaxLength(50)
                .HasColumnName("fPhone");
        });

        modelBuilder.Entity<TPhoto>(entity =>
        {
            entity.HasKey(e => e.Fid);

            entity.ToTable("tPhoto");

            entity.Property(e => e.Fid).HasColumnName("fid");
            entity.Property(e => e.FDate)
                .HasMaxLength(50)
                .HasColumnName("fDate");
            entity.Property(e => e.FDescription)
                .HasMaxLength(50)
                .HasColumnName("fDescription");
            entity.Property(e => e.FImage)
                .HasMaxLength(50)
                .HasColumnName("fImage");
            entity.Property(e => e.FOwnerId).HasColumnName("fOwnerID");
        });

        modelBuilder.Entity<Tcomment>(entity =>
        {
            entity.HasKey(e => e.Fid);

            entity.ToTable("TComment");

            entity.Property(e => e.Fid).HasColumnName("fid");
            entity.Property(e => e.FComment)
                .HasMaxLength(100)
                .HasColumnName("fComment");
            entity.Property(e => e.FDate)
                .HasMaxLength(50)
                .HasColumnName("fDate");
            entity.Property(e => e.FPost).HasColumnName("fPost");
            entity.Property(e => e.FUserId).HasColumnName("fUserId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
