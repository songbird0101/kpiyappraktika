using System;

class A
{
    public int a;
    public int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public double ComputeExpression()
    {
        return 1.0 / (1.0 + a + b / 2.0);
    }

    public int SquareDifference()
    {
        int diff = a - b;
        return diff * diff;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите a: ");
        int aVal = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите b: ");
        int bVal = Convert.ToInt32(Console.ReadLine());

        A obj = new A(aVal, bVal);

        Console.WriteLine("Значение a: " + obj.a);
        Console.WriteLine("Значение b: " + obj.b);
        Console.WriteLine("Результат выражения 1/(1+a+b/2) = " + obj.ComputeExpression());
        Console.WriteLine("Квадрат разности a и b = " + obj.SquareDifference());
    }
}