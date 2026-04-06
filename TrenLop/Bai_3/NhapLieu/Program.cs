using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapLieu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            do
            {
                Console.Write("Hay nhap vao so nguyen thuoc [1, 100]: ");
                num = int.Parse(Console.ReadLine());
            }while(num < 0 || num > 100);
        }
    }
}
