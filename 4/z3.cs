using System;

class Program
{
    static bool IsPrime(int n, int divisor = 2)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % divisor == 0) return false;
        if (divisor * divisor > n) return true;
        return IsPrime(n, divisor + 1);
    }

    static void Main()
    {
        Console.Write("Введите число: ");
        int num = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Число " + num + " простое? " + IsPrime(num));
    }
}