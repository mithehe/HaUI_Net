using QLNhaSach.Models;
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

namespace QLNhaSach
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

        QlnhaSachContext db = new QlnhaSachContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = (from nv in db.NhanViens
                        join dh in db.DonHangs on nv.MaNv equals dh.MaNv
                        select new
                        {
                            nv.MaNv,
                            nv.HoTen,
                            dh.MaDh,
                            dh.NgayDat,
                            dh.TongTien,
                        }).ToList();
            dgvHienThi.ItemsSource = query;
        }
    }
}
