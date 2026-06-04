using System;
using System.Collections.Generic;

namespace QuanLyCuaHangSach.Models;

public partial class Sach
{
    public string MaSach { get; set; } = null!;

    public string TenSach { get; set; } = null!;

    public int DonGia { get; set; }

    public int SoLuongTon { get; set; }

    public int MaTheLoai { get; set; }

    public virtual ICollection<ChiTietBanSach> ChiTietBanSaches { get; set; } = new List<ChiTietBanSach>();

    public virtual TheLoai MaTheLoaiNavigation { get; set; } = null!;
}
