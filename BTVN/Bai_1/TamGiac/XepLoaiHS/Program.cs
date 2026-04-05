using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLoaiHS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            float diem;

            Console.Write("Nhap ten hoc sinh: ");
            name = Console.ReadLine();
            Console.Write("Nhap diem hoc sinh: ");
            diem = float.Parse(Console.ReadLine());

            if (diem < 5)
            {
                Console.WriteLine($"Hoc sinh {name.ToUpper()} xep loai: Yeu");
            }
            else if (diem < 6.5)
            {
                Console.WriteLine($"Hoc sinh {name.ToUpper()} xep loai: Trung binh");
            }
            else if (diem < 8)
            {
                Console.WriteLine($"Hoc sinh {name.ToUpper()} xep loai: Kha");
            }
            else
            {
                Console.WriteLine($"Hoc sinh {name.ToUpper()} xep loai: Gioi");
            }
        }
    }
}
