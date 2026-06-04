using System;
using System.Collections.Generic;

namespace QLNhaSach.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string ChucVu { get; set; } = null!;

    public int Luong { get; set; }

    public int MaPhong { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual PhongBan MaPhongNavigation { get; set; } = null!;
}
