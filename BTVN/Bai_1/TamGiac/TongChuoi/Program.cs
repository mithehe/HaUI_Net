using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongChuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0, sum1 = 0;
            float sum2 = 0;
            try
            {
                do
                {
                    Console.Write("Nhap so nguyen duogn n: ");
                    n = int.Parse(Console.ReadLine());
                } while (n <= 0);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ban can nhap so nguyen duong");

            }

            for(int i = 1; i <= n; i++) {
                sum1 += i;
            }

            for(int i = 1; i <=n; i++) {
                sum2 += (float)1 / i;
            }

            Console.WriteLine($"Tong S = 1 + 2 + ... + {n} = {sum1}");
            Console.WriteLine($"Tong S = 1 + 1/2 + ....+ 1/{n} = {sum2:F2}");



        }
    }
}
