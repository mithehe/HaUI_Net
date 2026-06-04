using De_89037.Models;
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


namespace De_89037
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
        QlkhoHangContext db = new QlkhoHangContext();  
        public void LoadData()
        {
            dgvHienThi.ItemsSource = (from hang in db.HangHoas
                        where hang.SoLuongTon >= 0
                        orderby hang.SoLuongTon descending
                        select new
                        {
                            hang.MaHh,
                            hang.TenHh,
                            hang.SoLuongTon,
                            hang.DonGia,
                            hang.MaNcc,
                            GiaTriTon = hang.SoLuongTon * hang.DonGia,
                        }).ToList();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            cboNhaCC.ItemsSource = db.NhaCungCaps.ToList();
            cboNhaCC.DisplayMemberPath = "TenNcc";
            cboNhaCC.SelectedValuePath = "MaNcc";
            cboNhaCC.SelectedIndex = 0;
            LoadData();
        }

        public bool CheckInput()
        {
            if(string.IsNullOrWhiteSpace(txtMaHangHoa.Text) || string.IsNullOrWhiteSpace(txtTenHangHoa.Text))
            {
                MessageBox.Show("Mã hàng hóa và tên hàng hóa không được để trống");
                return false;
            }
            if(!int.TryParse(txtSoLuongTon.Text.Trim(), out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên dương");
                return false;
            }
            if (!int.TryParse(txtDonGia.Text.Trim(), out int dg) || dg <= 0)
            {
                MessageBox.Show("Đơn giá phải là số nguyên dương");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!CheckInput())
                {
                    return;
                }
                if(db.HangHoas.Any(h => h.MaHh == txtMaHangHoa.Text.Trim()))
                {
                    MessageBox.Show("Mã hàng hóa đã tồn tại!");
                    return;
                }

                HangHoa hh = new HangHoa();
                hh.MaHh = txtMaHangHoa.Text.Trim();
                hh.TenHh = txtTenHangHoa.Text.Trim();
                hh.SoLuongTon = int.Parse(txtSoLuongTon.Text.Trim());
                hh.DonGia = int.Parse(txtDonGia.Text.Trim());
                hh.MaNcc = cboNhaCC.SelectedValue.ToString();

                db.HangHoas.Add(hh);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã sảy ra lỗi khi thêm hàng hóa!");
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hangSua = db.HangHoas.FirstOrDefault(h => h.MaHh == txtMaHangHoa.Text.Trim());
                if (hangSua == null)
                {
                    MessageBox.Show("Không tìm thấy hàng để sửa!");
                    return;
                }
                else
                {
                    hangSua.TenHh = txtTenHangHoa.Text.Trim();
                    hangSua.MaNcc = cboNhaCC.SelectedValue.ToString();
                    hangSua.SoLuongTon = int.Parse(txtSoLuongTon.Text.Trim());
                    hangSua.DonGia = int.Parse(txtDonGia.Text.Trim());
                    hangSua.MaNcc = cboNhaCC.SelectedValue.ToString();

                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công!");
                    LoadData();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa hàng: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hangXoa = db.HangHoas.FirstOrDefault(h => h.MaHh == txtMaHangHoa.Text.Trim());
                if (hangXoa == null)
                {
                    MessageBox.Show("Không tìm thấy hàng để xoa!");
                    return;
                }
                else
                {
                    db.HangHoas.Remove(hangXoa);
                    db.SaveChanges();
                    MessageBox.Show("xóa thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hàng: " + ex.Message);
            }
        }
    }
}