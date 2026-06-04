using De_35912.Models;
using Microsoft.EntityFrameworkCore;
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

namespace De_35912
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
        QlnhanVienContext db = new QlnhanVienContext();

        public void Load_Data()
        {
            dgvHienThi.ItemsSource = (from nv in db.NhanViens
                                      where nv.LuongCb >= 5000000
                                      orderby nv.LuongCb ascending
                                      select new
                                      {
                                          nv.MaNv,
                                          TenNV = nv.HoTen,
                                          nv.NgaySinh,
                                          nv.LuongCb,
                                          MaPb = nv.MaPb,
                                          Luong = nv.LuongCb * 1.3,
                                      }).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboPhongBan.ItemsSource = db.PhongBans.ToList();
            cboPhongBan.DisplayMemberPath = "TenPb";
            cboPhongBan.SelectedValuePath = "MaPb";
            cboPhongBan.SelectedIndex = 0;
            Load_Data();
        }

        public bool Check_Input()
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text.Trim()) || string.IsNullOrEmpty(txtTenNhanVien.Text.Trim()))
            {
                MessageBox.Show("Mã và tên nhân viên không được để trống!");
                return false;
            }
            if (!DateTime.TryParse(txtNgaySinh.Text, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!");
                return false;
            }
            if (!float.TryParse(txtLuongCB.Text.Trim(), out float luongCB) || luongCB <= 0)
            {
                MessageBox.Show("Lương cơ bản cần lớn hơn 0 và là số thực!");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Check_Input())
                {
                    return;
                }
                if(db.NhanViens.Any(nv => nv.MaNv == txtMaNhanVien.Text.Trim()))
                {
                    MessageBox.Show("Đã tồn tại");
                    return;
                }

                NhanVien nv = new NhanVien();
                nv.MaNv = txtMaNhanVien.Text;
                nv.HoTen = txtTenNhanVien.Text;
                nv.NgaySinh = DateOnly.Parse(txtNgaySinh.Text);
                nv.LuongCb = float.Parse(txtLuongCB.Text);
                nv.MaPb = cboPhongBan.SelectedValue.ToString();

                db.NhanViens.Add(nv);
                db.SaveChanges();
                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi đã sảy ra: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nvSua = db.NhanViens.FirstOrDefault(nv => nv.MaNv == txtMaNhanVien.Text.Trim());
                if(nvSua == null)
                {
                    MessageBox.Show("Không tìm thấy để sửa" );
                    return;
                }

                nvSua.HoTen = txtTenNhanVien.Text;
                nvSua.NgaySinh = DateOnly.Parse(txtNgaySinh.Text);
                nvSua.LuongCb = float.Parse(txtLuongCB.Text);
                nvSua.MaPb = cboPhongBan.SelectedValue.ToString();

                db.SaveChanges();
                Load_Data();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi đã sảy ra: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nvXoa = db.NhanViens.FirstOrDefault(nv => nv.MaNv == txtMaNhanVien.Text.Trim());
                if (nvXoa == null)
                {
                    MessageBox.Show("Không tìm thấy để xóa");
                    return;
                }

                db.NhanViens.Remove(nvXoa);

                db.SaveChanges();
                Load_Data();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi đã sảy ra: " + ex.Message);
            }
        }
    }
}