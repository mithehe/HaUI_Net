using _2024609709_NguyenThiThuy_BT2.Models;
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



namespace _2024609709_NguyenThiThuy_BT2
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
        QuanLyTtdtContext db = new QuanLyTtdtContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvKhoaHoc.ItemsSource = db.KhoaHocs.ToList();
        }

        private bool KiemTraDuLieu(bool checkTrungMa = false)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhoaHoc.Text) || string.IsNullOrWhiteSpace(txtTenKhoaHoc.Text))
            {
                MessageBox.Show("Mã khóa học và Tên khóa học không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(txtSoTinChi.Text, out int soTinChi) || soTinChi <= 0)
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên dương!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!decimal.TryParse(txtHocPhi.Text, out decimal hocPhi) || hocPhi < 0)
            {
                MessageBox.Show("Học phí phải là số lớn hơn hoặc bằng 0!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (checkTrungMa)
            {
                var exists = db.KhoaHocs.Any(k => k.MaKhoaHoc == txtMaKhoaHoc.Text);
                if (exists)
                {
                    MessageBox.Show("Mã khóa học đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTraDuLieu(checkTrungMa: true)) return;

            var kh = new KhoaHoc
            {
                MaKhoaHoc = txtMaKhoaHoc.Text,
                TenKhoaHoc = txtTenKhoaHoc.Text,
                GiangVien = txtGiangVien.Text,
                SoTinChi = int.Parse(txtSoTinChi.Text),
                HocPhi = decimal.Parse(txtHocPhi.Text)
            };

            db.KhoaHocs.Add(kh);
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm thành công!");
        }

        private void dgvKhoaHoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvKhoaHoc.SelectedItem is KhoaHoc kh)
            {
                txtMaKhoaHoc.Text = kh.MaKhoaHoc;
                txtMaKhoaHoc.IsReadOnly = true; // Không cho sửa mã
                txtTenKhoaHoc.Text = kh.TenKhoaHoc;
                txtGiangVien.Text = kh.GiangVien;
                txtSoTinChi.Text = kh.SoTinChi.ToString();
                txtHocPhi.Text = kh.HocPhi.ToString(); 
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhoaHoc.Text)) return;
            if (!KiemTraDuLieu()) return;

            var kh = db.KhoaHocs.Find(txtMaKhoaHoc.Text);
            if (kh != null)
            {
                kh.TenKhoaHoc = txtTenKhoaHoc.Text;
                kh.GiangVien = txtGiangVien.Text;
                kh.SoTinChi = int.Parse(txtSoTinChi.Text);
                kh.HocPhi = decimal.Parse(txtHocPhi.Text);

                db.SaveChanges();
                LoadData();
                MessageBox.Show("Sửa thành công!");
            }

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var kh = db.KhoaHocs.Find(txtMaKhoaHoc.Text);
            if (kh != null)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa khóa học này?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    db.KhoaHocs.Remove(kh);
                    db.SaveChanges();
                    btnLamMoi_Click(null, null);
                    MessageBox.Show("Xóa thành công!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaKhoaHoc.Clear();
            txtMaKhoaHoc.IsReadOnly = false;
            txtTenKhoaHoc.Clear();
            txtGiangVien.Clear();
            txtSoTinChi.Clear();
            txtHocPhi.Clear();
            dgvKhoaHoc.SelectedItem = null;
            LoadData();
        }
    }


}
