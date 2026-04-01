using System;

class Mang
{
    static void Main(string[] args)
    {
        int length;
        Console.Write("Enter the length of the array: ");
        length = int.Parse(Console.ReadLine());

        int[] num = new int[length];
        Console.Write("Enter the elements of the array: ");
        for(int i = 0; i < num.Length; i++)
            num[i] = int.Parse(Console.ReadLine());

        int max = num[0];
        for(int i = 1; i < num.Length; i++)
        {
            if(num[i] > max)
                max = num[i];
        }
        Console.WriteLine("The largest element in the array is: " + max);

        int min = num[0];
        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] < min)
                min = num[i];
        }
        Console.WriteLine("The shorst element in the array is: " + min);

        int sum = 0;
        for(int i = 0; i < num.Length; i++)
            sum += num[i];
        Console.WriteLine("The sum of the elements in the array is: " + sum);
    }
}
