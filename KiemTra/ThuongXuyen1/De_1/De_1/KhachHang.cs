using System;

public class KhachHang
{
    // Biến thành viên private
    private string maKH;
    private string hoTen;
    private int soLuongMua;
    private double donGia;

    // Properties (Thuộc tính) cho phép truy cập an toàn
    public string MaKH { get => maKH; set => maKH = value; }
    public string HoTen { get => hoTen; set => hoTen = value; }
    public int SoLuongMua { get => soLuongMua; set => soLuongMua = value; }
    public double DonGia { get => donGia; set => donGia = value; }

    // Constructor không tham số
    public KhachHang() { }

    // Constructor đầy đủ tham số (Thay cho phương thức nhập theo yêu cầu)
    public KhachHang(string maKH, string hoTen, int soLuongMua, double donGia)
    {
        this.maKH = maKH;
        this.hoTen = hoTen;
        this.soLuongMua = soLuongMua;
        this.donGia = donGia;
    }

    // Phương thức tính tổng tiền
    public virtual double TinhTongTien()
    {
        return soLuongMua * donGia;
    }

    // Ghi đè ToString để hiển thị thông tin
    public override string ToString()
    {
        return $"{MaKH}\t{HoTen}\t{SoLuongMua}\t{DonGia}\t{TinhTongTien()}";
    }

    // Ghi đè Equals để kiểm tra trùng mã khách hàng
    public override bool Equals(object obj)
    {
        if (obj is KhachHang other)
        {
            return this.MaKH.Equals(other.MaKH);
        }
        return false;
    }
}