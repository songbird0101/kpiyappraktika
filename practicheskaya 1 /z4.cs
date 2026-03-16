using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите коэффициенты параболы y = ax^2 + bx + c:");

        Console.Write("a = ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("b = ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("c = ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (a == 0)
        {
            Console.WriteLine("Это не парабола (a = 0).");
        }
        else
        {
            double x0 = -b / (2 * a);
            double y0 = a * x0 * x0 + b * x0 + c; 

            Console.WriteLine("Координаты вершины параболы:");
            Console.WriteLine("x0 = " + x0);
            Console.WriteLine("y0 = " + y0);
        }

        Console.ReadKey();
    }
}