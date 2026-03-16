using System;

class Program
{
    static void Main()
    {
        double x = 2;

        double logExpr = Math.Log(Math.Exp(x) + 1) - 3;
        double sqrtVal = Math.Sqrt(logExpr);
        double tanPart = Math.Tan(sqrtVal);

        double sinX2 = Math.Sin(x * x);
        double cosX2 = Math.Cos(x * x);
        double fraction = sinX2 / (sinX2 - cosX2);

        double y = tanPart + fraction;

        Console.WriteLine("y = " + y);
    }
}