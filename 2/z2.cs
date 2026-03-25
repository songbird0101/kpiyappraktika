using System;

class Program
{
    static void Main()
    {
        int[] a = new int[25];
        int[] b = new int[25];

        Console.WriteLine("Введите 25 элементов массива a:");
        for (int i = 0; i < 25; i++)
        {
            Console.Write("a[" + i + "] = ");
            a[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Введите 25 элементов массива b:");
        for (int i = 0; i < 25; i++)
        {
            Console.Write("b[" + i + "] = ");
            b[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < 25; i++)
        {
            if (a[i] > 0)
                b[i] = b[i] * 10;
            else
                b[i] = 0;
        }

        Console.WriteLine("Преобразованный массив b:");
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine("b[" + i + "] = " + b[i]);
            Console.ReadKey();
        }
    }
}