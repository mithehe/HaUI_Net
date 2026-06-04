using System;
using System.Collections.Generic;

namespace De_89037.Models;

public partial class HangHoa
{
    public string MaHh { get; set; } = null!;

    public string? TenHh { get; set; }

    public int? DonGia { get; set; }

    public int? SoLuongTon { get; set; }

    public string? MaNcc { get; set; }

    public virtual NhaCungCap? MaNccNavigation { get; set; }
}
