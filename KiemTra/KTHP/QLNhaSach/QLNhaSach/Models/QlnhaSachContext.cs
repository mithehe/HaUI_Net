using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach.Models;

public partial class QlnhaSachContext : DbContext
{
    public QlnhaSachContext()
    {
    }

    public QlnhaSachContext(DbContextOptions<QlnhaSachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQL;Initial Catalog=QLNhaSach;Persist Security Info=True;User ID=sa;Password=1;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => new { e.MaDh, e.MaNv }).HasName("PK__DonHang__9557DB111B8DE187");

            entity.ToTable("DonHang");

            entity.Property(e => e.MaDh)
                .HasMaxLength(10)
                .HasColumnName("MaDH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .HasColumnName("MaNV");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DonHang__MaNV__3E52440B");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A2129BB41");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(150);

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__MaPhon__3A81B327");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__PhongBan__20BD5E5B09CDFBA4");

            entity.ToTable("PhongBan");

            entity.Property(e => e.TenPhong).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
