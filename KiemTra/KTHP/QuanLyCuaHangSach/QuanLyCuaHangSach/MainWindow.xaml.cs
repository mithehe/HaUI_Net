using QuanLyCuaHangSach.Models;
using System.Diagnostics.Eventing.Reader;
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

namespace QuanLyCuaHangSach
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
        QlcuaHangSachContext db = new QlcuaHangSachContext();

        public void LoadData()
        {
            dgvHienThi.ItemsSource = (from sach in db.Saches
                                      orderby sach.DonGia ascending
                                      select new
                                      {
                                          sach.MaSach,
                                          sach.TenSach,
                                          sach.MaTheLoai,
                                          sach.DonGia,
                                          sach.SoLuongTon,
                                          ThanhTien = sach.DonGia * sach.SoLuongTon,
                                      }).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            cboTheLoai.ItemsSource = db.TheLoais.ToList();
            cboTheLoai.DisplayMemberPath = "TenTheLoai";
            cboTheLoai.SelectedValuePath = "MaTheLoai";
            cboTheLoai.SelectedIndex = 0;
        }

        public bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtMaSach.Text.Trim()) || string.IsNullOrEmpty(txtTenSach.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã sách và tên sách!");
                return false;
            }
            if (!int.TryParse(txtDonGia.Text.Trim(), out int donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số nguyên lớn hơn 0!");
                return false;
            }
            if (!int.TryParse(txtSoLuongTon.Text.Trim(), out int sl) || sl < 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên lớn hơn 0!");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckInput())
                {
                    return;
                }
                if (db.Saches.Any(sach => sach.MaSach == txtMaSach.Text.Trim()))
                {
                    MessageBox.Show("Mã sách đã tồn tại, vui lòng chọn mã khác!");
                    return;
                }

                Sach s = new Sach();
                s.MaSach = txtMaSach.Text.Trim();
                s.TenSach = txtTenSach.Text.Trim();
                s.MaTheLoai = cboTheLoai.SelectedValue != null ? (int)cboTheLoai.SelectedValue : 0;
                s.DonGia = int.Parse(txtDonGia.Text.Trim());
                s.SoLuongTon = int.Parse(txtSoLuongTon.Text.Trim());

                db.Saches.Add(s);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckInput()) return;

                string maSach = txtMaSach.Text.Trim();
                // Tìm cuốn sách cần sửa trong DB
                var sachToUpdate = db.Saches.SingleOrDefault(s => s.MaSach == maSach);

                if (sachToUpdate != null)
                {
                    // Cập nhật thông tin
                    sachToUpdate.TenSach = txtTenSach.Text.Trim();
                    sachToUpdate.MaTheLoai = cboTheLoai.SelectedValue != null ? (int)cboTheLoai.SelectedValue : 0;
                    sachToUpdate.DonGia = int.Parse(txtDonGia.Text.Trim());
                    sachToUpdate.SoLuongTon = int.Parse(txtSoLuongTon.Text.Trim());

                    db.SaveChanges(); // Lưu thay đổi xuống CSDL
                    LoadData();       // Tải lại lưới dữ liệu
                    MessageBox.Show("Cập nhật sách thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã sách này để sửa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string maSach = txtMaSach.Text.Trim();
                if (string.IsNullOrEmpty(maSach))
                {
                    MessageBox.Show("Vui lòng nhập hoặc chọn mã sách cần xóa!");
                    return;
                }

                var sachToDelete = db.Saches.SingleOrDefault(s => s.MaSach == maSach);

                if (sachToDelete != null)
                {
                    // Hỏi xác nhận trước khi xóa
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa cuốn sách này?",
                                                        "Xác nhận xóa", MessageBoxButton.YesNo);
                    if (confirmResult == MessageBoxResult.Yes)
                    {
                        db.Saches.Remove(sachToDelete);
                        db.SaveChanges();
                        LoadData();

                        // Reset form
                        txtMaSach.Clear();
                        txtTenSach.Clear();
                        txtDonGia.Clear();
                        txtSoLuongTon.Clear();
                        MessageBox.Show("Xóa sách thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã sách này để xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            Search winThongKe = new Search();
            winThongKe.ShowDialog();
        }

        private void dgvHienThi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                // Kiểm tra xem người dùng có đang chọn dòng nào không
                if (dgvHienThi.SelectedItem != null)
                {
                    // Sử dụng dynamic vì ItemsSource đang là một Anonymous Type (chứa cột ThanhTien tự tính)
                    dynamic selectedRow = dgvHienThi.SelectedItem;

                    // Đổ dữ liệu từ dòng được chọn lên các TextBox và ComboBox
                    txtMaSach.Text = selectedRow.MaSach;
                    txtTenSach.Text = selectedRow.TenSach;
                    cboTheLoai.SelectedValue = selectedRow.MaTheLoai;
                    txtDonGia.Text = selectedRow.DonGia.ToString();
                    txtSoLuongTon.Text = selectedRow.SoLuongTon.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        }

    }
}