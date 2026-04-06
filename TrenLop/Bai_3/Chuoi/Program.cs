using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Nhap vao mot chuoi: ");
            string s = Console.ReadLine();
            if (DoiXung(s))
            {
                Console.WriteLine("Chuoi doi xung");
            }
            else
            {
                Console.WriteLine("Chuoi khong doi xung");
            }
        }

        static bool DoiXung(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
