using System;
using System.Collections.Generic;

namespace QLNhaSach.Models;

public partial class DonHang
{
    public string MaDh { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public DateOnly NgayDat { get; set; }

    public int TongTien { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
