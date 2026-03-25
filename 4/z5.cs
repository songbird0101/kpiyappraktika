using System;

abstract class Shape3D
{
    public abstract double CalculateVolume();
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Это 3D фигура");
    }
}

class Sphere : Shape3D
{
    private double radius;
    public Sphere(double radius)
    {
        this.radius = radius;
    }
    public override double CalculateVolume()
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Сфера с радиусом {radius}. Объем: {CalculateVolume():F2}");
    }
}

class Cube : Shape3D
{
    private double side;
    public Cube(double side)
    {
        this.side = side;
    }
    public override double CalculateVolume()
    {
        return Math.Pow(side, 3);
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Куб со стороной {side}. Объем: {CalculateVolume():F2}");
    }
}

class Program
{
    static void Main()
    {
        Shape3D sphere = new Sphere(5);
        Shape3D cube = new Cube(4);
        sphere.DisplayInfo();
        cube.DisplayInfo();
    }
}