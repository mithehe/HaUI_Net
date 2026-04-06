using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TachDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.Write("Hay nhap vao day so: ");
            str = Console.ReadLine();
            TachDay(str);
        }

        static void TachDay(string str)
        {
            int[] arr;
            arr = str.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    Console.Write($"{arr[i]}  ");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    Console.Write($"{arr[i]}  ");
                }
            }


        }
    }
}
