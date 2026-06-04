using De_7.Models;
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

namespace De_7
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
        QlduocPhamContext db = new QlduocPhamContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cboDanhMuc.ItemsSource = db.DanhMucThuocs.ToList();
                cboDanhMuc.DisplayMemberPath = "TenDm";
                cboDanhMuc.SelectedValuePath = "MaDm";
                cboDanhMuc.SelectedIndex = 0; // Đừng quên dòng này để tránh lỗi null nhé

                LoadData();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi để biết chính xác nguyên nhân
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message + "\n\nChi tiết: " + ex.InnerException?.Message);
            }
        }

        private void LoadData()
        {
            dgvHienThi.ItemsSource = (from thuoc in db.Thuocs
                                      where thuoc.SoLuong <= 200
                                      orderby thuoc.SoLuong descending
                                      select new
                                      {
                                          thuoc.MaThuoc,
                                          thuoc.TenThuoc,
                                          thuoc.MaDm,
                                          thuoc.GiaBan,
                                          thuoc.SoLuong,
                                          ThanhTien = thuoc.GiaBan * thuoc.SoLuong
                                      }).ToList();
        }

        private bool checkInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaThuoc.Text) || string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã và tên thuốc!");
                return false;
            }

            if (!double.TryParse(txtGiaThuoc.Text, out double giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là số thực dương!");
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!checkInput())
                {
                    return;
                }
                if (db.Thuocs.Any(t => t.MaThuoc == txtMaThuoc.Text))
                {
                    MessageBox.Show("Mã thuốc đã tồn tại!");
                    return;
                }

                Thuoc thuoc = new Thuoc();
                thuoc.MaThuoc = txtMaThuoc.Text;
                thuoc.TenThuoc = txtTenThuoc.Text;
                thuoc.MaDm = cboDanhMuc.SelectedValue.ToString();

                thuoc.GiaBan = double.Parse(txtGiaThuoc.Text);
                thuoc.SoLuong = int.Parse(txtSoLuong.Text);

                db.Thuocs.Add(thuoc);
                db.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thuốc: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var thuocSua = db.Thuocs.FirstOrDefault(t => t.MaThuoc == txtMaThuoc.Text);
                if (thuocSua == null)
                {
                    MessageBox.Show("Không tìm thấy thuốc để sửa!");
                    return;
                }
                thuocSua.TenThuoc = txtTenThuoc.Text;
                thuocSua.MaDm = cboDanhMuc.SelectedValue.ToString();

                thuocSua.GiaBan = double.Parse(txtGiaThuoc.Text);
                thuocSua.SoLuong = int.Parse(txtSoLuong.Text);

                db.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thuốc: " + ex.Message);
            }  
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var thuocXoa = db.Thuocs.FirstOrDefault(t => t.MaThuoc == txtMaThuoc.Text);
                if(thuocXoa == null)
                {
                    MessageBox.Show("Không tìm thấy thuốc để xóa!");
                    return;
                }
                var result = MessageBox.Show($"Bạn có chắc muốn xóa thuốc {thuocXoa.TenThuoc}?", "Xác nhận", 
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    db.Thuocs.Remove(thuocXoa);
                    db.SaveChanges();
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thuốc: " + ex.Message);
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {

            WindowTimKiem frm = new WindowTimKiem();
            frm.Show(); // Sang cửa sổ khác 
        }
    }
}