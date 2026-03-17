using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите A: ");
        int A = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите B: ");
        int B = Convert.ToInt32(Console.ReadLine());

        int N = B - A + 1;

        Console.WriteLine("Числа от " + A + " до " + B + ":");
        for (int i = A; i <= B; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Количество чисел: " + N);
    }
}