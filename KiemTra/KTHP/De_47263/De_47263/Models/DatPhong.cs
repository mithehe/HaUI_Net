using System;
using System.Collections.Generic;

namespace De_47263.Models;

public partial class DatPhong
{
    public string MaDp { get; set; } = null!;

    public string? TenKhach { get; set; }

    public int? SoNgayO { get; set; }

    public double? GiaPhong { get; set; }

    public string MaLoai { get; set; } = null!;

    public virtual LoaiPhong MaLoaiNavigation { get; set; } = null!;
}
