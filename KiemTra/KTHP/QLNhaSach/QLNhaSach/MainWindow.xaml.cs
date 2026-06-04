using QLNhaSach.Models;
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

namespace QLNhaSach
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
        QlnhaSachContext db = new QlnhaSachContext();
        public void LoadData()
        {
            dgvHienThi.ItemsSource = (from nv in db.NhanViens
                                      orderby nv.Luong descending
                                      select new
                                      {
                                          nv.MaNv,
                                          nv.HoTen,
                                          nv.ChucVu,
                                          nv.Luong,
                                          nv.MaPhong,
                                          nv.MaPhongNavigation.TenPhong
                                      }).ToList();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            cboPhongBan.ItemsSource = db.PhongBans.ToList();
            cboPhongBan.DisplayMemberPath = "TenPhong";
            cboPhongBan.SelectedValuePath = "MaPhong";
            cboPhongBan.SelectedIndex = 0;
        }

        public bool CheckInput()
        {
            if(!int.TryParse(txtLuong.Text.Trim(), out int salary) || salary < 0)
            {
                MessageBox.Show("Lương phải là số nguyên lớn hơn 0");
                return false;
            }
            return true;
        }

        private void dgvHienThi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvHienThi.SelectedItem == null)
            {
                return;
            }

            dynamic row = dgvHienThi.SelectedItem;
            txtMaNV.Text = row.MaNv;
            txtTenNV.Text = row.HoTen;
            txtChucVu.Text = row.ChucVu;
            txtLuong.Text = row.Luong.ToString();
            cboPhongBan.SelectedValue = row.MaPhong;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckInput())
                {
                    return;
                }
                if(db.NhanViens.Any(nv => nv.MaNv == txtMaNV.Text.Trim()))
                {
                    MessageBox.Show("Mã nhân viên đã có trong bảng, vui lòng nhập mã khác");
                    return;
                }

                NhanVien nv = new NhanVien();
                nv.MaNv = txtMaNV.Text.Trim();
                nv.HoTen = txtTenNV.Text.Trim();
                nv.ChucVu = txtChucVu.Text.Trim();
                nv.Luong = int.Parse(txtLuong.Text.Trim());
                nv.MaPhong = (int)cboPhongBan.SelectedValue;

                db.NhanViens.Add(nv);
                db.SaveChanges();
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nvSua = db.NhanViens.FirstOrDefault(nv => nv.MaNv == txtMaNV.Text.Trim());
                if(nvSua == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần sửa");
                    return;
                }

                nvSua.HoTen = txtTenNV.Text.Trim();
                nvSua.ChucVu = txtChucVu.Text.Trim();
                nvSua.Luong = int.Parse(txtLuong.Text.Trim());
                nvSua.MaPhong = (int)cboPhongBan.SelectedValue;

                db.SaveChanges();
                MessageBox.Show("Sửa nhân viên thành công!");
                LoadData();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nvXoa = db.NhanViens.FirstOrDefault(nv => nv.MaNv == txtMaNV.Text.Trim());
                if (nvXoa == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa");
                    return;
                }

                string maNV = txtMaNV.Text.Trim();
                MessageBoxResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên có mã {maNV} không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool daCoDonHang = db.DonHangs.Any(dh => dh.MaNv == maNV);
                    if (daCoDonHang)
                    {
                        MessageBox.Show("Không thể xóa! Nhân viên này đã có đơn hàng trong hệ thống.", "Lỗi dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                        return; 
                    }

                    db.NhanViens.Remove(nvXoa);
                    db.SaveChanges();

                    MessageBox.Show("Xóa nhân viên thành công!");
                    LoadData(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.ShowDialog();
        }
    }
}