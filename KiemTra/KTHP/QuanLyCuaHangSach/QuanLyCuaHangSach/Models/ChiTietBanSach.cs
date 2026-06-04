using System;
using System.Collections.Generic;

namespace QuanLyCuaHangSach.Models;

public partial class ChiTietBanSach
{
    public string MaHd { get; set; } = null!;

    public string MaSach { get; set; } = null!;

    public DateOnly NgayBan { get; set; }

    public int SoLuongBan { get; set; }

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
