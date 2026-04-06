using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhToan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            Console.Write("a = ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            num2 = int.Parse(Console.ReadLine());

            char c;
            Console.Write("Phep toan (+, -, *, /): ");
            c = char.Parse(Console.ReadLine());
            switch(c)
            {
                case '+':
                    Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                    break;
                case '-':
                    Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                    break;
                case '*':
                    Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                    break;
                case '/':
                    if (num2 != 0)
                        Console.WriteLine($"{num1} / {num2} = {(float)num1 / num2}");
                    else
                        Console.WriteLine("Khong the chia cho 0");
                    break;
                default:
                    Console.WriteLine("Phep toan khong hop le");
                    break;
            }

        }
    }
}
