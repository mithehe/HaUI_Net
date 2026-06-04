using De_23841.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace De_23841
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
        QlsanPhamContext db = new QlsanPhamContext();
        public void LoadData()
        {
            dgvHienThi.ItemsSource = (from sp in db.SanPhams
                         orderby sp.SoLuong descending
                         select new
                         {
                             sp.MaSp,
                             sp.TenSp,
                             sp.DonGia,
                             sp.SoLuong,
                             sp.MaDm,
                             ThanhTien = sp.DonGia * sp.SoLuong,

                         }).ToList();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboDanhMuc.ItemsSource = db.DanhMucs.ToList();
            cboDanhMuc.DisplayMemberPath = "TenDm";
            cboDanhMuc.SelectedValuePath = "MaDm";
            cboDanhMuc.SelectedIndex = 0;
            LoadData();

        }

        public bool CheckInput()
        {
            if(string.IsNullOrEmpty(txtMaSanPham.Text) || string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                MessageBox.Show("Mã sản phẩm và tên sản phẩm không được để trống!");
                return false;
            }
            if(!double.TryParse(txtDonGia.Text.Trim(), out double donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số nguyên dương!");
                return false;
            }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số nguyên dương!");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            if(db.SanPhams.Any(sp => sp.MaSp == txtMaSanPham.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại");
                return;
            }

            SanPham sp = new SanPham();
            sp.MaSp = txtMaSanPham.Text.Trim();
            sp.TenSp = txtTenSanPham.Text.Trim();
            sp.DonGia= double.Parse(txtDonGia.Text.Trim());
            sp.SoLuong = int.Parse(txtSoLuong.Text.Trim());
            sp.MaDm = cboDanhMuc.SelectedValue.ToString();

            db.SanPhams.Add(sp);
            db.SaveChanges();
            LoadData();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var spSua = db.SanPhams.FirstOrDefault(sp => sp.MaSp == txtMaSanPham.Text.Trim());
            if(spSua == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm để sửa!");
                return;
            }
            spSua.TenSp = txtTenSanPham.Text.Trim();
            spSua.DonGia = double.Parse(txtDonGia.Text.Trim());
            spSua.SoLuong = int.Parse(txtSoLuong.Text.Trim());
            spSua.MaDm = cboDanhMuc.SelectedValue.ToString();
            
            db.SaveChanges();
            LoadData();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var  spXoa = db.SanPhams.FirstOrDefault(sp => sp.MaSp == txtMaSanPham.Text.Trim());
            if (spXoa == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm để xóa!");
                return;
            }

            db.SanPhams.Remove(spXoa);
            db.SaveChanges();
            LoadData();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            WindowThongKe thongKeWindow = new WindowThongKe();
            thongKeWindow.Show();
        }
    }
}