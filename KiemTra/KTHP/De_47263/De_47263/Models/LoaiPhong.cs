using System;
using System.Collections.Generic;

namespace De_47263.Models;

public partial class LoaiPhong
{
    public string MaLoai { get; set; } = null!;

    public string? TenLoai { get; set; }

    public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();
}
