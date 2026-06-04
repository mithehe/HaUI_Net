using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_3
{
    class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public float SoTienBanHang { get; set; }
        public float TienHoaHong { get { return SoTienBanHang * 0.1f; } }

    }
}
