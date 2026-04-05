using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float chieuDai, chieuRong, chuVi, dienTich;
            Console.Write("Nhap chieu dai cua hinh chu nhat: ");
            chieuDai = float.Parse(Console.ReadLine());
            Console.Write("Nhap chieu rong cua hinh chu nhat: ");
            chieuRong = float.Parse(Console.ReadLine());

            Console.WriteLine($"Chu vi cua hinh chu nhat la: {(chieuDai + chieuRong)*2}");
            Console.WriteLine($"Dien tich cua hinh chu nhat la: {chieuDai * chieuRong}");

        }
    }
}
