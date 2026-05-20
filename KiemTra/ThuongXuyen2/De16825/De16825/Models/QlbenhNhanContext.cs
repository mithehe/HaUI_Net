using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace De16825.Models;

public partial class QlbenhNhanContext : DbContext
{
    public QlbenhNhanContext()
    {
    }

    public QlbenhNhanContext(DbContextOptions<QlbenhNhanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BacSy> BacSies { get; set; }

    public virtual DbSet<BenhNhan> BenhNhans { get; set; }

    public virtual DbSet<KhoaKham> KhoaKhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQL;Initial Catalog=QLBenhNhan;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BacSy>(entity =>
        {
            entity.HasKey(e => e.MaBs).HasName("PK__BacSy__27247596142D7013");

            entity.ToTable("BacSy");

            entity.Property(e => e.MaBs)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaBS");
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.SoDt)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SoDT");
        });

        modelBuilder.Entity<BenhNhan>(entity =>
        {
            entity.HasKey(e => e.Mabn).HasName("PK__BenhNhan__272369957655B59B");

            entity.ToTable("BenhNhan");

            entity.Property(e => e.Mabn)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Diachi).HasMaxLength(100);
            entity.Property(e => e.Hoten).HasMaxLength(50);
            entity.Property(e => e.Makhoa)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SongayNv).HasColumnName("SongayNV");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.BenhNhans)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK_BenhNhan_KhoaKham");
        });

        modelBuilder.Entity<KhoaKham>(entity =>
        {
            entity.HasKey(e => e.Makhoa).HasName("PK__KhoaKham__5E7F1383564C2BB4");

            entity.ToTable("KhoaKham");

            entity.Property(e => e.Makhoa)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Tenkhoa).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
