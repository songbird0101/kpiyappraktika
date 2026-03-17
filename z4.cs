using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        double y = 0;
        if (x >= 4 && x <= 6)
            y = x;
        if (x > 6)
            y = 3 * x + 4 * x * x;

        Console.WriteLine("y = " + y);
    }
}