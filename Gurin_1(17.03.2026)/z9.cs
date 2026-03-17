using System;

class Program
{
    static void Main()
    {
        double A = 0.1;
        double B = 2.1;
        int M = 20;
        double H = (B - A) / M;

        for (int i = 0; i <= M; i++)
        {
            double x = A + i * H;
            double y = x * x * Math.Exp(-x);
            Console.WriteLine(x + " " + y);
        }
    }
}