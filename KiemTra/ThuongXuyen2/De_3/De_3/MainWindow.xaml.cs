using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace De_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<NhanVien> ds = new List<NhanVien>();


        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (isCheck())
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = txtMaNV.Text.Trim();
                nv.HoTen = txtHoTen.Text.Trim();
                if (rbNam.IsChecked == true)
                    nv.GioiTinh = "Nam";
                else
                    nv.GioiTinh = "Nữ";
                nv.SoTienBanHang = float.Parse(txtSoTienBanHang.Text.Trim());
                ds.Add(nv);

                dgvHienThi.ItemsSource = null;
                dgvHienThi.ItemsSource = ds;
            }
            
        }

        private void btnWin2_Click(object sender, RoutedEventArgs e)
        {
            List<NhanVien> nhanVienMax = new List<NhanVien>();
            var max = ds.Max(nv => nv.SoTienBanHang);
            var query = ds.FindAll(nv => nv.SoTienBanHang == max);
            nhanVienMax.AddRange(query);

            Window2 window2 = new Window2();
            window2.dgvHienThi.ItemsSource = nhanVienMax;
            window2.Show();
        }

        private bool isCheck() {
            if(string.IsNullOrEmpty(txtMaNV.Text.Trim()) || string.IsNullOrEmpty(txtHoTen.Text.Trim()) || string.IsNullOrEmpty(txtSoTienBanHang.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (ds.Any(nv => nv.MaNV == txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(!float.TryParse(txtSoTienBanHang.Text.Trim(), out float soTienBanHang) || soTienBanHang <= 0)
            {
                MessageBox.Show("Số tiền bán hàng không hợp lệ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
