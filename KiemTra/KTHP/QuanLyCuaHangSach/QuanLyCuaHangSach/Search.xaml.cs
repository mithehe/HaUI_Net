using QuanLyCuaHangSach.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyCuaHangSach
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }
        QlcuaHangSachContext db = new QlcuaHangSachContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from ct in db.ChiTietBanSaches
                      join s in db.Saches on ct.MaSach equals s.MaSach
                      join tl in db.TheLoais on s.MaTheLoai equals tl.MaTheLoai
                      group ct by new { s.MaSach, s.TenSach, tl.TenTheLoai, s.DonGia } into g
                      select new
                      {
                          MaSach = g.Key.MaSach,
                          TenSach = g.Key.TenSach,
                          TenTheLoai = g.Key.TenTheLoai,
                          // Tính tổng số lượng bán
                          SoLuongDaBan = g.Sum(x => x.SoLuongBan),
                          // Tính tổng tiền = Đơn giá * Tổng số lượng bán
                          TongTienBanSach = g.Key.DonGia * g.Sum(x => x.SoLuongBan)
                      };

            dgvHienThi.ItemsSource = query.ToList();
        }
    }
}
