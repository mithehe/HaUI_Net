using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bacLuong;
            int ngayCong;
            int phuCap;

            Console.WriteLine("Nhap bac luong: ");
            bacLuong = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap ngay cong: ");
            ngayCong = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap phu cap: ");
            phuCap = int.Parse(Console.ReadLine());

            int NCTL;
            if (ngayCong < 25) NCTL = ngayCong;
            else NCTL = 25 + (ngayCong - 25) * 2;

            long luong = (long)bacLuong * 1490000 * NCTL + phuCap;
            Console.WriteLine("Luong: " + luong + "VND");
        }
    }
}
