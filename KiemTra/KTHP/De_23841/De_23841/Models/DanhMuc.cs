using System;
using System.Collections.Generic;

namespace De_23841.Models;

public partial class DanhMuc
{
    public string MaDm { get; set; } = null!;

    public string? TenDm { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
