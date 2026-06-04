using QLKhachSan.Models;
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

namespace QLKhachSan
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
        QlkhachSanContext db = new QlkhachSanContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvHienThi.ItemsSource = (from p in db.Phongs
                                     join dp in db.DatPhongs on p.MaPhong equals dp.MaPhong
                                     join kh in db.KhachHangs on dp.MaKh equals kh.MaKh
                                     where p.TrangThai == "Đã đặt"
                                     select new
                                     {
                                            p.MaPhong,
                                            p.LoaiPhong,
                                            p.GiaThue,
                                            kh.HoTen,
                                            dp.NgayNhanPhong,
                                            dp.NgayTraPhong,
                                            dp.TongTien
                                     }).ToList();
        }
    }
}
