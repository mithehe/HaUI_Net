using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_6
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
            }while (num < 0);
        }
    }
}
