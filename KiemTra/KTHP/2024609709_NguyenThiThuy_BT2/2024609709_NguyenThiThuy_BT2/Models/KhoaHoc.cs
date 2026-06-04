using System;
using System.Collections.Generic;

namespace _2024609709_NguyenThiThuy_BT2.Models;

public partial class KhoaHoc
{
    public string MaKhoaHoc { get; set; } = null!;

    public string TenKhoaHoc { get; set; } = null!;

    public string? GiangVien { get; set; }

    public int? SoTinChi { get; set; }

    public decimal? HocPhi { get; set; }
}
