using System;

class Program
{
    static void Main()
    {
        int rows = 3;
        int cols = 4;
        int[,] arr = new int[rows, cols];
        Random rnd = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                arr[i, j] = rnd.Next(0, 10);
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }

        int product = 1;
        bool foundOdd = false;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (arr[i, j] % 2 != 0)
                {
                    product *= arr[i, j];
                    foundOdd = true;
                }
            }
        }

        if (foundOdd)
            Console.WriteLine("Произведение нечётных элементов: " + product);
        else
            Console.WriteLine("Нечётных элементов нет");

        Console.Write("Введите номер строки (от 1 до " + rows + "): ");
        int k = Convert.ToInt32(Console.ReadLine());

        if (k >= 1 && k <= rows)
        {
            int sum = 0;
            for (int j = 0; j < cols; j++)
            {
                sum += arr[k - 1, j];
            }
            Console.WriteLine("Сумма элементов строки " + k + ": " + sum);
        }
        else
        {
            Console.WriteLine("Некорректный номер строки");
            Console.ReadKey();
        }
    }
}