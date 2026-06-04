using System;
using System.Collections.Generic;

namespace QLKhachSan.Models;

public partial class DatPhong
{
    public string MaDatPhong { get; set; } = null!;

    public string MaKh { get; set; } = null!;

    public string MaPhong { get; set; } = null!;

    public DateOnly NgayNhanPhong { get; set; }

    public DateOnly NgayTraPhong { get; set; }

    public int TongTien { get; set; }

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
