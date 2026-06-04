using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<KhachHang> danhSachKH = new List<KhachHang>();

    static void Main(string[] args)
    {
        string chon;
        do
        {
            Console.WriteLine("\n--- MENU QUAN LY KHACH HANG ---");
            Console.WriteLine("1. Nhap thong tin");
            Console.WriteLine("2. Hien thi danh sach");
            Console.WriteLine("3. Tim khach hang co so luong mua lon nhat");
            Console.WriteLine("4. Sap xep danh sach theo so luong giam dan");
            Console.WriteLine("5. Thoat");
            Console.Write("Chon chuc nang: ");
            chon = Console.ReadLine();

            switch (chon)
            {
                case "1": NhapThongTin(); break;
                case "2": HienThiDanhSach(); break;
                case "3": TimMaxSoLuong(); break;
                case "4": sx(); break;
                case "5": break;
                default: Console.WriteLine("Nhap sai, vui long chon lai!"); break;
            }
        } while (chon != "5");
    }

    static void NhapThongTin()
    {
        Console.WriteLine("1. Khach hang thuong | 2. Khach hang VIP");
        string loai = Console.ReadLine();

        Console.Write("Ma KH: "); string ma = Console.ReadLine();

        // Kiểm tra trùng mã (Sử dụng Equals đã ghi đè)
        if (danhSachKH.Any(k => k.MaKH == ma))
        {
            Console.WriteLine("Loi: Ma khach hang da ton tai!");
            return;
        }

        Console.Write("Ho ten: "); string ten = Console.ReadLine();
        Console.Write("So luong mua: "); int sl = int.Parse(Console.ReadLine());
        Console.Write("Don gia: "); double dg = double.Parse(Console.ReadLine());

        if (loai == "1")
            danhSachKH.Add(new KhachHang(ma, ten, sl, dg));
        else if (loai == "2")
            danhSachKH.Add(new KhachHangVIP(ma, ten, sl, dg));
    }

    static void HienThiDanhSach()
    {
        Console.WriteLine("\nMa\tHo Ten\tSL\tDon Gia\tTong Tien\tQua Tang");
        foreach (var kh in danhSachKH)
        {
            Console.WriteLine(kh.ToString());
        }
    }

    static void TimMaxSoLuong()
    {
        if (danhSachKH.Count == 0) return;

        int maxSL = danhSachKH.Max(k => k.SoLuongMua);
        var dsMax = danhSachKH.Where(k => k.SoLuongMua == maxSL);

        Console.WriteLine("\nKhach hang co so luong mua lon nhat:");
        foreach (var kh in dsMax)
        {
            Console.WriteLine(kh.ToString());
        }
    }

    static void sx()
    {
        var ds = danhSachKH.OrderByDescending(k => k.SoLuongMua).ThenBy(k => k.HoTen);
        Console.WriteLine("Danh sach so luong giam dan)");
        foreach (var kh in ds)
        {
            Console.WriteLine(kh.ToString());
        }
    }

    static void xoaKH()
    {
        Console.Write("Moi nhap ma khach hang can xoa");
        string maXoa = Console.ReadLine();
        var checkXoa = danhSachKH.FirstOrDefault(h => h.MaKH == maXoa);
        if (checkXoa != null)
        {
            danhSachKH.Remove(checkXoa);
            Console.WriteLine("Da xoa");
        }
        else
        {
            Console.WriteLine("Khong co de xoa");
        }
    }
}