using System;
using System.Collections.Generic;

namespace QLNhaSach.Models;

public partial class PhongBan
{
    public int MaPhong { get; set; }

    public string TenPhong { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
