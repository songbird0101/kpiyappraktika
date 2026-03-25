using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] % 3 == 0)
                sum += arr[i];
        }

        Console.WriteLine("Сумма чисел кратных трём: " + sum);
        Console.ReadKey();
    }
}