using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите а: ");
        int A = Convert.ToInt32(Console.ReadLine());

        Console.Write("введите б: ");
        int B = Convert.ToInt32(Console.ReadLine());

        int product = 1;
        for (int i = A; i <= B; i++)
        {
            product *= i;
        }

        Console.WriteLine("произведение чисел от " + A + " до " + B + " = " + product);
    }
}