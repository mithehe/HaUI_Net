using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace De_47263.Models;

public partial class QldatPhongContext : DbContext
{
    public QldatPhongContext()
    {
    }

    public QldatPhongContext(DbContextOptions<QldatPhongContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatPhong> DatPhongs { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQL;Initial Catalog=QLDatPhong;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.HasKey(e => e.MaDp).HasName("PK__DatPhong__27258669DFD54EA8");

            entity.ToTable("DatPhong");

            entity.Property(e => e.MaDp)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaDP");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TenKhach).HasMaxLength(100);

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DatPhong__MaLoai__4BAC3F29");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiPhon__730A5759C6AFF2CD");

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
