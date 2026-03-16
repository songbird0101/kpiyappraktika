using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите трёхзначное число: ");
        string chislo = Console.ReadLine();

        int a = chislo[0] - '0';
        int b = chislo[1] - '0';
        int c = chislo[2] - '0';

        int proizvedenie = a * b * c;

        Console.WriteLine("Произведение цифр: " + proizvedenie);
        Console.ReadKey();
    }
}