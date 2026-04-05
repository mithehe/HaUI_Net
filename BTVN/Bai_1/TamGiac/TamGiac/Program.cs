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
            float a, b, c;
            do
            {
                Console.Write("Nhap canh a: ");
                a = float.Parse(Console.ReadLine());
                Console.Write("Nhap canh b: ");
                b = float.Parse(Console.ReadLine());
                Console.Write("Nhap canh c: ");
                c = float.Parse(Console.ReadLine());
            }while(a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a);

            float P = (a + b + c);
            float p = (a + b + c) / 2;
            float s = (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine($"Chu vi tam giac: {P}");
            Console.WriteLine($"Dien tich tam giac: {s}");
        }
    }
}
