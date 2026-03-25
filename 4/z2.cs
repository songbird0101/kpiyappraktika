

class Program
{
    static void AddRightDigit(int D, ref int K)
    {
        K = K * 10 + D;
    }

    static void Main()
    {
        Console.Write("Введите число K: ");
        int K = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите первую цифру D1 (0-9): ");
        int D1 = Convert.ToInt32(Console.ReadLine());

        AddRightDigit(D1, ref K);
        Console.WriteLine("После добавления D1: " + K);

        Console.Write("Введите вторую цифру D2 (0-9): ");
        int D2 = Convert.ToInt32(Console.ReadLine());

        AddRightDigit(D2, ref K);
        Console.WriteLine("После добавления D2: " + K);
        Console.ReadKey();
    }
}