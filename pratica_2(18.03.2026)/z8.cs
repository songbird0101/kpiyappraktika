using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string str = Console.ReadLine();
        Console.Write("Введите суффикс: ");
        string suffix = Console.ReadLine();

        bool result = str.EndsWith(suffix);
        Console.WriteLine("Результат: " + result);
        Console.ReadKey();
    }
}