using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace De_89037.Models;

public partial class QlkhoHangContext : DbContext
{
    public QlkhoHangContext()
    {
    }

    public QlkhoHangContext(DbContextOptions<QlkhoHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HangHoa> HangHoas { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQL;Initial Catalog=QLKhoHang;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.HasKey(e => e.MaHh).HasName("PK__HangHoa__2725A6E47151647C");

            entity.ToTable("HangHoa");

            entity.Property(e => e.MaHh)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaHH");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaNCC");
            entity.Property(e => e.TenHh)
                .HasMaxLength(100)
                .HasColumnName("TenHH");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.HangHoas)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK__HangHoa__MaNCC__398D8EEE");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEBB26FD644");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaNCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(50)
                .HasColumnName("TenNCC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
