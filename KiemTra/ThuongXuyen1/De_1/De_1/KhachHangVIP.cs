public class KhachHangVIP : KhachHang
{
    // Constructor kế thừa từ lớp cha
    public KhachHangVIP() : base() { }

    public KhachHangVIP(string maKH, string hoTen, int soLuongMua, double donGia)
        : base(maKH, hoTen, soLuongMua, donGia) { }

    // Phương thức xác định quà tặng dựa trên tổng tiền
    public string XacDinhQuaTang()
    {
        double tongTien = TinhTongTien();
        if (tongTien < 1000) return "Coupon 100";
        if (tongTien <= 5000) return "Coupon 200";
        return "Coupon 500";
    }

    // Ghi đè ToString để thêm thông tin quà tặng
    public override string ToString()
    {
        return base.ToString() + $"\t{XacDinhQuaTang()}";
    }
}