using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day;
            Console.Write("Nhap vao so: ");

            switch(day = int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Hom nay la chu nhat");
                    break;
                case 2:
                    Console.WriteLine("Hom nay la thu 2");
                    break;
                case 3:
                    Console.WriteLine("Hom nay la thu 3");
                    break;
                case 4:
                    Console.WriteLine("Hom nay la thu 4");
                    break;
                case 5:
                    Console.WriteLine("Hom nay la thu 5");
                    break;
                case 6:
                    Console.WriteLine("Hom nay la thu 6");
                    break;
                case 7:
                    Console.WriteLine("Hom nay la thu 7");
                    break;
                default:
                    Console.WriteLine("Khong co ngay nao trong tuan co so " + day);
                    break;
            }
        }
    }
}
