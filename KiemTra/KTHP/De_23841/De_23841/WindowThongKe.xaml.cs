using De_23841.Models;
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

namespace De_23841
{
    /// <summary>
    /// Interaction logic for WindowThongKe.xaml
    /// </summary>
    public partial class WindowThongKe : Window
    {
        QlsanPhamContext db = new QlsanPhamContext();
        public WindowThongKe()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvHienThi.ItemsSource = db.DanhMucs.Select(dm => new
            {
                MaDm = dm.MaDm,
                TenDm = dm.TenDm,
                TongTien = dm.SanPhams.Sum(sp => sp.DonGia * sp.SoLuong)
            }).ToList();

        }
    }
}
