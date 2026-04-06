using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so phan tu cua mang ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            Console.WriteLine("Nhap cac phan tu cua mang");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            foreach (int x in arr)
            {
                if (x % 2 != 0)
                    sum += x;
            }
            Console.WriteLine($"Tong cac phan tu le trong mang: {sum}");
        }
    }
}
