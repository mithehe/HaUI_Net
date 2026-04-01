using System;

class Fibonaci {     
    static void Main(string[] args)
    {
        int n;
        Console.Write("Nhap so n: ");
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{FibonaciN(i)} ");
        }
    }
    static int FibonaciN(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return FibonaciN(n - 1) + FibonaciN(n - 2);
    }
}