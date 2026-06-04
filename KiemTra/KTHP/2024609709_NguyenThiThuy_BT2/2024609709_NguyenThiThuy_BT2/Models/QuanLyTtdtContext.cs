using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _2024609709_NguyenThiThuy_BT2.Models;

public partial class QuanLyTtdtContext : DbContext
{
    public QuanLyTtdtContext()
    {
    }

    public QuanLyTtdtContext(DbContextOptions<QuanLyTtdtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=M502\\SQLEXPRESS;Initial Catalog=QuanLyTTDT;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KhoaHoc>(entity =>
        {
            entity.HasKey(e => e.MaKhoaHoc);

            entity.ToTable("KhoaHoc");

            entity.Property(e => e.MaKhoaHoc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GiangVien).HasMaxLength(100);
            entity.Property(e => e.HocPhi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenKhoaHoc).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
