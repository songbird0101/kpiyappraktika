using System;

public static class StringExtensions
{
    public static bool IsDigitsOnly(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return false;

        foreach (char c in str)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        if (input.IsDigitsOnly())
            Console.WriteLine("Строка содержит только цифры.");
        else
            Console.WriteLine("Строка содержит нецифровые символы.");
    }
}