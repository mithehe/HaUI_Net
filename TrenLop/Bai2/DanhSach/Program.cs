using System;

class DanhSach
{
    static void Main(string[] args)
    {
        string num;
        Console.Write("Moi ban nhap vao day so: ");
        num = Console.ReadLine();

        int[] daySo = Array.ConvertAll(num.Split(new char[] { ' ', '#', '.' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        TachChuoi(daySo);

    }

    static void TachChuoi(int[] num)
    {
        Console.Write("Day so chan la: ");
        for (int i = 0; i < num.Length; i++)
        {
            if(num[i] % 2 == 0)
                Console.Write($"{num[i]} ");
        }

        Console.Write("\nDay so le la: ");
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i] % 2 != 0)
                Console.Write($"{num[i]} ");
        }

        Console.Write("\nDay so nguyen to la: ");
        for (int i = 0; i < num.Length; i++)
        {
            if (KtraSoNguyenTo(num[i]))
                Console.Write($"{num[i]} ");
        }

    }

    static bool KtraSoNguyenTo(int n)
    {
        if (n < 2) return false;
        else
        {
            for(int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
        }
        return true;
    }
}