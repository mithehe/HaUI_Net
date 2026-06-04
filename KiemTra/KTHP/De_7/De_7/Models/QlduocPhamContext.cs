using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace De_7.Models;

public partial class QlduocPhamContext : DbContext
{
    public QlduocPhamContext()
    {
    }

    public QlduocPhamContext(DbContextOptions<QlduocPhamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DanhMucThuoc> DanhMucThuocs { get; set; }

    public virtual DbSet<Thuoc> Thuocs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.\\SQL;Initial Catalog=QLDuocPham;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DanhMucThuoc>(entity =>
        {
            entity.HasKey(e => e.MaDm).HasName("PK__DanhMucT__2725866E5A8BC01A");

            entity.ToTable("DanhMucThuoc");

            entity.Property(e => e.MaDm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaDM");
            entity.Property(e => e.TenDm)
                .HasMaxLength(50)
                .HasColumnName("TenDM");
        });

        modelBuilder.Entity<Thuoc>(entity =>
        {
            entity.HasKey(e => e.MaThuoc).HasName("PK__Thuoc__4BB1F620CD00A087");

            entity.ToTable("Thuoc");

            entity.Property(e => e.MaThuoc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaDm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaDM");
            entity.Property(e => e.TenThuoc).HasMaxLength(30);

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.Thuocs)
                .HasForeignKey(d => d.MaDm)
                .HasConstraintName("FK__Thuoc__MaDM__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
