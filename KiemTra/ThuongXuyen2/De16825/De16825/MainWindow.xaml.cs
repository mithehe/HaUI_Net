using De16825.Models;
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

namespace De16825
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

        QlbenhNhanContext db = new QlbenhNhanContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDgv();
            cboKhoaKham.ItemsSource = db.KhoaKhams.ToList();
            cboKhoaKham.DisplayMemberPath = "Tenkhoa";
            cboKhoaKham.SelectedValuePath = "Makhoa";
            cboKhoaKham.SelectedIndex = 0;
        }

        private void LoadDgv()
        {
            dgvHienThi.ItemsSource = (from bn in db.BenhNhans
                                     where bn.SongayNv > 20
                                     orderby bn.SongayNv descending
                                     select new
                                     {
                                         bn.Mabn,
                                         bn.Hoten,
                                         bn.Makhoa,
                                         bn.Diachi,
                                         bn.SongayNv,
                                         VienPhi = bn.SongayNv * 60000,
                                     }).ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (is_Check())
            {
                BenhNhan bn = new BenhNhan();
                bn.Mabn = txtMaBenhNhan.Text.Trim();
                bn.Hoten = txtHoTen.Text.Trim();
                bn.Diachi = txtDiaChi.Text.Trim();
                bn.SongayNv = int.Parse(txtSoNgayNamVien.Text.Trim());
                bn.Makhoa = cboKhoaKham.SelectedValue.ToString();
                
                db.BenhNhans.Add(bn);
                db.SaveChanges();
                
                LoadDgv();
            }
        }

        private bool is_Check()
        {
            if(!int.TryParse(txtSoNgayNamVien.Text.Trim(), out int songay))
            {
                MessageBox.Show("Số ngày nằm viện phải là số nguyên");
                return false;
            }
            return true;
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (is_Check())
            {
                dynamic benhNhan = dgvHienThi.SelectedItem;
                string maBenhNhan;
                if (benhNhan != null)
                {
                    maBenhNhan = benhNhan.Mabn;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân cần sửa!");
                    return;
                }

                // Tìm bệnh nhân trong CSDL
                var hasBn = db.BenhNhans.FirstOrDefault(bn => bn.Mabn == maBenhNhan);
                if (hasBn != null)
                {
                    // SỬA TẠI ĐÂY: Gán giá trị mới cho 'hasBn' (đối tượng của EF Core)
                    hasBn.Hoten = txtHoTen.Text.Trim();
                    hasBn.Diachi = txtDiaChi.Text.Trim();
                    hasBn.SongayNv = int.Parse(txtSoNgayNamVien.Text.Trim());
                    hasBn.Makhoa = cboKhoaKham.SelectedValue.ToString();

                    // Lưu thay đổi vào DB
                    db.SaveChanges();
                    LoadDgv();

                    MessageBox.Show("Sửa thành công!");
                }
            }
        }
    }
}