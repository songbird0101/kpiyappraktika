
class Program
{
    static string InvertCase(string input)
    {
        char[] chars = input.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsLower(chars[i]))
                chars[i] = char.ToUpper(chars[i]);
            else if (char.IsUpper(chars[i]))
                chars[i] = char.ToLower(chars[i]);
        }
        return new string(chars);
    }

    static void Main()
    {
        Console.Write("Введите строку: ");
        string str = Console.ReadLine();
        string result = InvertCase(str);
        Console.WriteLine("Результат: " + result);
        Console.ReadKey();
    }
}