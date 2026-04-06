using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamGiac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.Write("Nhap vao do dai canh a: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao do dai canh b: ");
            b = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao do dai canh c: ");
            c = int.Parse(Console.ReadLine());
            if (KiemTraTamGiac(a, b, c))
            {
                Console.WriteLine($"Chu vi tam giac: {TinhChuVi(a, b, c)}");
                Console.WriteLine($"Dien tich tam giac: {TinhDienTich(a, b, c)}");
            }
            else
            {
                Console.WriteLine("Khong phai la 3 canh cua mot tam giac");
            }

        }

        static bool KiemTraTamGiac(int a, int b, int c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);   
        }

        static int TinhChuVi(int a, int b, int c)
        {
            return a + b + c;
        }

        static float TinhDienTich(int a, int b, int c)
        {
            float p = TinhChuVi(a, b, c) / 2f;
            return (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
