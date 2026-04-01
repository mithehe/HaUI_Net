using System;

class GiaiThua
{
    static void Main(String[] args)
    {
        int num;
        Console.Write("Nhap so can tinh giai thua ");
        num = int.Parse(Console.ReadLine());
        Console.WriteLine($"{num}! = {GT(num)}");
    }

    static long GT(int n)
    {
        long kq = 1;
        for (int i = 2; i <= n; i++)
            kq *= i;
        return kq;
    }
}
