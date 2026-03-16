using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите значение x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        double logExpr = Math.Log(Math.Exp(x) + 1) - 3;
        double sqrtVal = Math.Sqrt(logExpr);
        double tanPart = Math.Tan(sqrtVal);

        double sinX2 = Math.Sin(x * x);
        double cosX2 = Math.Cos(x * x);
        double denominator = sinX2 - cosX2;
        double fraction = sinX2 / denominator;

        double y = tanPart + fraction;

        Console.WriteLine("y = " + y);
    }
}