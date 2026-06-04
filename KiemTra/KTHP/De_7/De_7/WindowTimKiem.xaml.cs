using De_7.Models;
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

namespace De_7
{
    /// <summary>
    /// Interaction logic for WindowTimKiem.xaml
    /// </summary>
    public partial class WindowTimKiem : Window
    {
        QlduocPhamContext db = new QlduocPhamContext();
        public WindowTimKiem()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = db.DanhMucThuocs.Select(dm => new
            {
                MaDM = dm.MaDm,
                TenDM = dm.TenDm,
                TongTien = dm.Thuocs.Sum(t => (double?)t.GiaBan * t.SoLuong) ?? 0 
            }).ToList();

            dgThongKe.ItemsSource = query;
        }
    }
}
