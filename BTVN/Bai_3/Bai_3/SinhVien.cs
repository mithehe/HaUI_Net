using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuanLySinhVien
{
    struct SinhVien
    {
        public int id;
        public string ten;
        public string gioiTinh;
        public int tuoi;
        public double diemToan;
        public double diemLy;
        public double diemHoa;
        public double diemTB;
        public string hocLuc;

        public void TinhDiemVaXepLoai()
        {
            diemTB = (diemToan + diemLy + diemHoa) / 3;
            if (diemTB >= 8) hocLuc = "Gioi";
            else if (diemTB >= 6.5) hocLuc = "Kha";
            else if (diemTB >= 5) hocLuc = "Trung Binh";
            else hocLuc = "Yeu";
        }
    }

    class Program
    {
        static List<SinhVien> danhSachSV = new List<SinhVien>();
        static string fileName = "student.txt";
        static int currentID = 0;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DocFile(); 

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Cap nhat thong tin");
                Console.WriteLine("3. Xoa sinh vien boi ID");
                Console.WriteLine("4. Tìm kiếm sinh viên theo tên");
                Console.WriteLine("5. Sx theo diem trung binh");
                Console.WriteLine("6. Sx theo ten");
                Console.WriteLine("7. Hien thi danh sach sinh vien");
                Console.WriteLine("8. Ghi danh sach vào file student.txt");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                try
                {
                    int chon = int.Parse(Console.ReadLine());
                    switch (chon)
                    {
                        case 1: ThemSinhVien(); break;
                        case 2: CapNhatSinhVien(); break;
                        case 3: XoaSinhVien(); break;
                        case 4: TimKiemTheoTen(); break;
                        case 5: SapXepTheoDiem(); break;
                        case 6: SapXepTheoTen(); break;
                        case 7: HienThiDanhSach(danhSachSV); break;
                        case 8: GhiFile(); break;
                        case 0: return;
                        default: Console.WriteLine("Khong hop le!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }

        static void ThemSinhVien()
        {
            SinhVien sv = new SinhVien();
            currentID++;
            sv.id = currentID;
            Console.Write("Nhap ten: "); sv.ten = Console.ReadLine();
            Console.Write("Nhap gioi tinh: "); sv.gioiTinh = Console.ReadLine();
            Console.Write("Nhap tuoi: "); sv.tuoi = int.Parse(Console.ReadLine());
            Console.Write("Diem toan: "); sv.diemToan = double.Parse(Console.ReadLine());
            Console.Write("Diem ly: "); sv.diemLy = double.Parse(Console.ReadLine());
            Console.Write("Diem hoa: "); sv.diemHoa = double.Parse(Console.ReadLine());
            sv.TinhDiemVaXepLoai();
            danhSachSV.Add(sv);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        static void CapNhatSinhVien()
        {
            Console.Write("Nhap id can sua: ");
            int id = int.Parse(Console.ReadLine());
            int index = danhSachSV.FindIndex(s => s.id == id);

            if (index != -1)
            {
                SinhVien sv = danhSachSV[index];
                Console.Write("Ten: "); sv.ten = Console.ReadLine();
                Console.Write("Gioi tinh: "); sv.gioiTinh = Console.ReadLine();
                Console.Write("Tuoi: "); sv.tuoi = int.Parse(Console.ReadLine());
                Console.Write("Diem toan: "); sv.diemToan = double.Parse(Console.ReadLine());
                Console.Write("Diem ly: "); sv.diemLy = double.Parse(Console.ReadLine());
                Console.Write("Diem hoa: "); sv.diemHoa = double.Parse(Console.ReadLine());
                sv.TinhDiemVaXepLoai();
                danhSachSV[index] = sv;
                Console.WriteLine("Cap nhat thanh cong!");
            }
            else Console.WriteLine("Khong thay ID!");
        }

        static void XoaSinhVien()
        {
            Console.Write("NHap ID can xoa: ");
            int id = int.Parse(Console.ReadLine());
            int removedCount = danhSachSV.RemoveAll(s => s.id == id);
            if (removedCount > 0) Console.WriteLine("Da xoa.");
            else Console.WriteLine("Khong thay ID!");
        }

        static void TimKiemTheoTen()
        {
            Console.Write("Nhap ten can tim ");
            string keyword = Console.ReadLine().ToLower();
            var ketQua = danhSachSV.Where(s => s.ten.ToLower().Contains(keyword)).ToList();
            HienThiDanhSach(ketQua);
        }

        static void SapXepTheoDiem()
        {
            danhSachSV = danhSachSV.OrderBy(s => s.diemTB).ToList();
            Console.WriteLine("Xep theo chieu tang dan.");
        }

        static void SapXepTheoTen()
        {
            danhSachSV = danhSachSV.OrderBy(s => s.ten).ToList();
            Console.WriteLine("Ten (A-Z).");
        }

        static void HienThiDanhSach(List<SinhVien> list)
        {
            Console.WriteLine("\n{0,-5} {1,-20} {2,-10} {3,-5} {4,-5} {5,-5} {6,-5} {7,-10} {8,-10}",
                "ID", "Ten", "Gioi tinh", "Tuoi", "Toan", "Ly", "Hoa", "ĐTB", "Hoc luc");
            foreach (var sv in list)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-5} {4,-5} {5,-5} {6,-5} {7,-10:F2} {8,-10}",
                    sv.id, sv.ten, sv.gioiTinh, sv.tuoi, sv.diemToan, sv.diemLy, sv.diemHoa, sv.diemTB, sv.hocLuc);
            }
        }

        static void GhiFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (var sv in danhSachSV)
                    {
                        sw.WriteLine($"{sv.id}|{sv.ten}|{sv.gioiTinh}|{sv.tuoi}|{sv.diemToan}|{sv.diemLy}|{sv.diemHoa}|{sv.diemTB}|{sv.hocLuc}");
                    }
                }
                Console.WriteLine("Da luu vao file student.txt");
            }
            catch (Exception ex) { Console.WriteLine("Loi ghi file: " + ex.Message); }
        }

        static void DocFile()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string[] lines = File.ReadAllLines(fileName);
                    foreach (string line in lines)
                    {
                        string[] p = line.Split('|');
                        SinhVien sv = new SinhVien();
                        sv.id = int.Parse(p[0]);
                        sv.ten = p[1];
                        sv.gioiTinh = p[2];
                        sv.tuoi = int.Parse(p[3]);
                        sv.diemToan = double.Parse(p[4]);
                        sv.diemLy = double.Parse(p[5]);
                        sv.diemHoa = double.Parse(p[6]);
                        sv.diemTB = double.Parse(p[7]);
                        sv.hocLuc = p[8];
                        danhSachSV.Add(sv);
                        if (sv.id > currentID) currentID = sv.id;
                    }
                    Console.WriteLine("Da tai du lieu file.");
                }
            }
            catch (Exception) { Console.WriteLine("Khong the doc file."); }
        }
    }
}