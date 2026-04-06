using System;
using System.Collections.Generic;
using System.Linq; 

namespace DanhSach
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<double> num = new List<double>();

            Console.WriteLine("Nhap 5 phan tu cua danh sach:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Phan tu {i + 1}: ");
                
                double value = double.Parse(Console.ReadLine());
                num.Add(value);
            }

            
            num.Sort();
            Console.WriteLine("\nDanh sach theo thu tu tang dan:");
            InDanhSach(num);

            num.RemoveAll(a => a < 0);
            Console.WriteLine("\nDanh sach sau khi xoa cac so âm:");
            InDanhSach(num);

            
            Console.Write("\nNhap vao so x bat ky: ");
            double x = double.Parse(Console.ReadLine());

            
            int index = 0;
            while (index < num.Count && num[index] < x)
            {
                index++;
            }
            num.Insert(index, x); 

            Console.WriteLine("Danh sach sau khi chen x:");
            InDanhSach(num);

            
        }

        
        static void InDanhSach(List<double> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}