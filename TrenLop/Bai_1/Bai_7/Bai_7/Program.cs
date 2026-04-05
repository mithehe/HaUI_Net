using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.Write("Moi nhap so nguyen n:");
            a = int.Parse(Console.ReadLine());
            if (IsPrime(a))
            {
                Console.WriteLine($"{a} la so nguyen to");
            } else Console.WriteLine($"{a} khong la so nguyen to");

        }

        public static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
