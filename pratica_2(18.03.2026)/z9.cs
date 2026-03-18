using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        bool isFloat = double.TryParse(input, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out _);

        Console.WriteLine("Результат: " + isFloat);
        Console.ReadKey();
    }
}