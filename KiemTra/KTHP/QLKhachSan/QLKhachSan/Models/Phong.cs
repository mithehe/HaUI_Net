using System;
using System.Collections.Generic;

namespace QLKhachSan.Models;

public partial class Phong
{
    public string MaPhong { get; set; } = null!;

    public string LoaiPhong { get; set; } = null!;

    public int GiaThue { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();
}
