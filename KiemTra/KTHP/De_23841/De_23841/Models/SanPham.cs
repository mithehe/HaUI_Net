using System;
using System.Collections.Generic;

namespace De_23841.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public double? DonGia { get; set; }

    public int? SoLuong { get; set; }

    public string? MaDm { get; set; }

    public virtual DanhMuc? MaDmNavigation { get; set; }
}
