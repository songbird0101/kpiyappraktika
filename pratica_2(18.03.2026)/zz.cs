using System;
using System.Text;

class Program
{
    static bool StartsWith(StringBuilder sb, string prefix)
    {
        if (sb == null || prefix == null)
            return false;
        if (prefix.Length > sb.Length)
            return false;
        for (int i = 0; i < prefix.Length; i++)
        {
            if (sb[i] != prefix[i])
                return false;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Введите строку для StringBuilder: ");
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder(input);

        Console.Write("Введите подстроку: ");
        string prefix = Console.ReadLine();

        bool result = StartsWith(sb, prefix);
        Console.WriteLine("Результат: " + result);
        Console.ReadKey();
    }
}