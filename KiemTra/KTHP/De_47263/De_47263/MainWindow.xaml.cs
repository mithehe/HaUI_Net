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
using De_47263.Models;

namespace De_47263
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

        QldatPhongContext db = new QldatPhongContext();
        public void LoadData()
        {
            dgvHienThi.ItemsSource = (from p in db.DatPhongs
                                      where p.SoNgayO <= 7
                                      orderby p.SoNgayO descending
                                      select new
                                      {
                                          p.MaDp,
                                          p.TenKhach,
                                          p.MaLoai,
                                          p.SoNgayO,
                                          p.GiaPhong,
                                          TongTien = p.SoNgayO * p.GiaPhong,
                                      }).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboLoaiPhong.ItemsSource = db.LoaiPhongs.ToList();
            cboLoaiPhong.DisplayMemberPath = "TenLoai";
            cboLoaiPhong.SelectedValuePath = "MaLoai";
            cboLoaiPhong.SelectedIndex = 0;
            LoadData();
        }

        public bool CheckInput()
        {
            if(string.IsNullOrEmpty(txtMaDatPhong.Text) || string.IsNullOrEmpty(txtTenKhach.Text))
            {
                MessageBox.Show("Mã đặt phòng và tên khách hàng không được để trống");
                return false;
            }
            if(!float.TryParse(txtGiaPhong.Text.Trim(), out float giaPhong) || giaPhong <= 0)
            {
                MessageBox.Show("Giá phòng cần là số dương");
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
                if(db.DatPhongs.Any(p => p.MaDp == txtMaDatPhong.Text.Trim()))
                {
                    MessageBox.Show("Mã đặt phòng đã tồn tại");
                    return;
                }

                DatPhong p = new DatPhong();
                p.MaDp = txtMaDatPhong.Text.Trim();
                p.TenKhach = txtTenKhach.Text.Trim();
                p.SoNgayO = int.Parse(txtSoNgayO.Text.Trim());
                p.GiaPhong = float.Parse(txtGiaPhong.Text.Trim());
                p.MaLoai = cboLoaiPhong.SelectedValue.ToString();

                db.DatPhongs.Add(p);
                db.SaveChanges();
                LoadData();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var p = db.DatPhongs.FirstOrDefault(p => p.MaDp == txtMaDatPhong.Text.Trim());
            try
            {
                
                if (p == null)
                {
                    MessageBox.Show("Không thấy phòng");
                    return;
                }

                p.TenKhach = txtTenKhach.Text.Trim();
                p.SoNgayO = int.Parse(txtSoNgayO.Text.Trim());
                p.GiaPhong = float.Parse(txtGiaPhong.Text.Trim());
                p.MaLoai = cboLoaiPhong.SelectedValue.ToString();

                db.SaveChanges();
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var p = db.DatPhongs.FirstOrDefault(p => p.MaDp == txtMaDatPhong.Text.Trim());
            try
            {

                if (p == null)
                {
                    MessageBox.Show("Không thấy phòng");
                    return;
                }

                db.DatPhongs.Remove(p);
                db.SaveChanges();
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}