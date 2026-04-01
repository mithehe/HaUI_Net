using System;

class Chuoi
{
    static void Main(string[] args)
    {
        List<string> ThanhPho = new List<string>();
        
        //Nhap cac ten thanh pho
        for(int i = 0; i < 5; i++)
        {
            Console.Write($"Nhap ten thanh pho thu {i + 1}: ");
            string tp = Console.ReadLine();
            ThanhPho.Add(tp);
        }

        //Sap xep theo thu tu tu A - Z
        Console.WriteLine("\nTen cac thanh pho tu A-Z");
        ThanhPho.Sort();

        //In ten cac thanh pho ra man hinh
        foreach (string tenTP in ThanhPho)
        {
            Console.WriteLine(tenTP);
        }

        //Xoa khoi danh sach ten thanh pho Ha Noi
        if (ThanhPho.Contains("Ha Noi"))
        {
            ThanhPho.RemoveAll(tp => tp == "Ha Noi");
        }
        else
            Console.WriteLine("Khong co thanh pho Ha Noi trong danh sach");

        //In lai danh sach sau khi xoa
        Console.WriteLine("\nDanh sach cac thanh pho sau khi xoa");
        foreach (string tenTP in ThanhPho)
        {
            Console.WriteLine(tenTP);
        }
    }
}