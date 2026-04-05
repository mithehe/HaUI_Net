using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            do
            {
                Console.Write("Nhap so nguyen duong: ");
                num = int.Parse(Console.ReadLine());
            } while (num < 0);

            for(int i = 1; i <= num; i++)
            {
                if(i % 5 == 0)
                {
                    continue;
                }
                Console.Write($"{i} ");
            }
        }
    }
}
