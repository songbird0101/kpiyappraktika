using System;

class Z1
{
    static void Main()
    {
        Console.WriteLine("вычисление площади треугольника");
        Console.WriteLine("введите исходные данные:");

        Console.Write("основание в см: ");
        int osnovanie = Convert.ToInt32(Console.ReadLine());

        Console.Write("высота в см: ");
        int vysota = Convert.ToInt32(Console.ReadLine());

        int ploshchad = osnovanie * vysota / 2;

        Console.WriteLine("площадь треугольника: {0} кв.см", ploshchad);
        Console.ReadKey();
    }
}