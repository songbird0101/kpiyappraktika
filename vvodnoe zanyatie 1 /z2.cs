using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите трехзначное число:");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number < 100 || number > 999)
        {
            Console.WriteLine("Ошибка: число не трехзначное");
            return;
        }
        int firstDigit = number / 100;
        int lastTwo = number % 100;
        int newNumber = lastTwo * 10 + firstDigit;
        Console.WriteLine("Полученное число: " + newNumber);
        Console.ReadKey();
    }
}