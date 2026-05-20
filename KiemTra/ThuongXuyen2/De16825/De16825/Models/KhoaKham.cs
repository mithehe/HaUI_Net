using System;
using System.Collections.Generic;

namespace De16825.Models;

public partial class KhoaKham
{
    public string Makhoa { get; set; } = null!;

    public string? Tenkhoa { get; set; }

    public virtual ICollection<BenhNhan> BenhNhans { get; set; } = new List<BenhNhan>();
}
