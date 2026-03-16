using System;

class Program
{
    static void Main()
    {
       
        Console.WriteLine("Введите значение b (b >= 2):");

        double b = Convert.ToDouble(Console.ReadLine());

        double sqrtB2Minus4 = Math.Sqrt(b * b - 4);
        double z1 = Math.Sqrt(2 * b + 2 * sqrtB2Minus4) / (sqrtB2Minus4 + b + 2);
        double z2 = 1 / Math.Sqrt(b + 2);

        Console.WriteLine("Результаты:");
        Console.WriteLine("z1 = {0:F6}", z1);
        Console.WriteLine("z2 = {0:F6}", z2);
        Console.WriteLine("Разность: {0:E}", z1 - z2);

        Console.ReadKey();
    }
}