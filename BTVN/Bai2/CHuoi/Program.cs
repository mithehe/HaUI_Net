using System;

class Chuoi
{
    static void Main(string[] args)
    {
        Console.WriteLine("Moi ban nhap chuoi ki tu");
        string chuoi = Console.ReadLine();

        //Hien thi moi ki tu tren 1 dong
        for (int i = 0; i < chuoi.Length; i++)
        {
            Console.WriteLine($"{chuoi[i]} ");
        }

        //Hien thi moi ki tu tren mot dong(bo qua ki tu trang)
        foreach (char ch in chuoi)
            if (!char.IsWhiteSpace(ch)) //IsWhiteSpace dung de kiem tra ki tu space, xuong dong, ....
                Console.WriteLine(ch);

        //Hien thi so lan xuat hien cua ki tu
        Dictionary<char, int> count = new Dictionary<char, int>();
        foreach (char ch in chuoi)
        {
            if(count.ContainsKey(ch))
                count[ch]++;
            else
                count[ch] = 1;
        }
        foreach (var item in count)
        {
            Console.WriteLine($"{item.Key}:{item.Value}");
        }
    }
}
