using System;

class HinhChuNhat
{
    static void Main(string[] args)
    {
        int dai, rong;

        Console.Write("Chieu dai: ");
        dai = int.Parse(Console.ReadLine());

        Console.Write("Chieu rong: ");
        rong = int.Parse(Console.ReadLine());

        Console.WriteLine($"Chu vi: {(dai + rong) * 2}");
        Console.WriteLine($"Dien tich: {(dai * rong)}");
    }
}
