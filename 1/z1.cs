using System;

class Square
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public double GetPerimeter()
    {
        return 4 * side;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("введите сторону квадрата: ");
        double inputSide = Convert.ToDouble(Console.ReadLine());

        Square mySquare = new Square(inputSide);
        double perimeter = mySquare.GetPerimeter();

        Console.WriteLine("периметр квадрата: " + perimeter);
    }
