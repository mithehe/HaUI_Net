using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyCuaHangSach.Models;

public partial class QlcuaHangSachContext : DbContext
{
    public QlcuaHangSachContext()
    {
    }

    public QlcuaHangSachContext(DbContextOptions<QlcuaHangSachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietBanSach> ChiTietBanSaches { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQL;Initial Catalog=QLCuaHangSach;User ID=sa;Password=1;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietBanSach>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSach }).HasName("PK__ChiTietB__EC06F1A2B6A1D6EA");

            entity.ToTable("ChiTietBanSach");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaSach).HasMaxLength(10);

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietBanSaches)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietBa__MaSac__3F466844");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__Sach__B235742DB58F12F6");

            entity.ToTable("Sach");

            entity.Property(e => e.MaSach).HasMaxLength(10);
            entity.Property(e => e.TenSach).HasMaxLength(150);

            entity.HasOne(d => d.MaTheLoaiNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTheLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sach__MaTheLoai__3B75D760");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTheLoai).HasName("PK__TheLoai__D73FF34A459D6A50");

            entity.ToTable("TheLoai");

            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
