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
using Microsoft.EntityFrameworkCore;
using QLKhachSan.Models;

namespace QLKhachSan
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
        QlkhachSanContext db  = new QlkhachSanContext();
        public void LoadData()
        {
            dgvHienThi.ItemsSource = (from p in db.Phongs
                                      orderby p.GiaThue ascending
                                      select new
                                      {
                                          p.MaPhong,
                                          p.LoaiPhong,
                                          p.GiaThue,
                                          p.TrangThai,
                                      }).ToList();


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            cboTrangThai.ItemsSource = new List<string> { "Trống", "Đã đặt" };
            cboTrangThai.SelectedIndex = 0;
        }

        private void dgvHienThi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgvHienThi.SelectedItem == null)
            {
                return;
            }
            dynamic row = dgvHienThi.SelectedItem;
            txtMaPhong.Text = row.MaPhong;
            txtLoaiPhong.Text = row.LoaiPhong;
            txtGiaThue.Text = row.GiaThue.ToString();
            cboTrangThai.SelectedValue = row.MaPhong;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!int.TryParse(txtGiaThue.Text.Trim(), out int gia) || gia <= 0)
                {
                    MessageBox.Show("Giá thuê phỉa là số nguyên và  > 0");
                    return;
                }
                if(db.Phongs.Any(p => p.MaPhong == txtMaPhong.Text.Trim()))
                {
                    MessageBox.Show("Mã phòng đã tồn tại");
                    return;
                }

                Phong p = new Phong();
                p.MaPhong = txtMaPhong.Text.Trim();
                p.LoaiPhong = txtLoaiPhong.Text.Trim();
                p.GiaThue = gia;
                p.TrangThai = cboTrangThai.Text;

                db.Phongs.Add(p);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pSua = db.Phongs.FirstOrDefault(p => p.MaPhong == txtMaPhong.Text.Trim());
                if (pSua == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng để sửa!");
                    return;
                }

                pSua.LoaiPhong = txtLoaiPhong.Text.Trim();
                pSua.GiaThue = int.Parse(txtGiaThue.Text.Trim());
                pSua.TrangThai = cboTrangThai.Text;

                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pXoa = db.Phongs.FirstOrDefault(p => p.MaPhong == txtMaPhong.Text.Trim());
                if (pXoa == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng để xóa!");
                    return;
                }
                string maPhong = txtMaPhong.Text.Trim();

                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool flag = db.DatPhongs.Any(k => k.MaKh ==  maPhong);
                    if (flag)
                    {
                        MessageBox.Show("Phòng đã có khách đặt không thể xóa!", "Lỗi dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                    else
                    {
                        db.Phongs.Remove(pXoa);
                        db.SaveChanges();
                        txtMaPhong.Clear();
                        txtLoaiPhong.Clear();
                        txtGiaThue.Clear();
                        MessageBox.Show("Xóa thành công");
                        LoadData();
                    }   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            Search win = new Search();
            win.ShowDialog();
        }
    }
}