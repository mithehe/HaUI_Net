using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao so nguyen: ");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0) Console.WriteLine($"{num} la so chan");
            else Console.WriteLine($"{num} la so le");

            if (num > 0) Console.WriteLine($"{num} la so khong am");
            else Console.WriteLine($"{num} la so am");
        }
    }
}
