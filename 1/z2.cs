using System;

class Program
{
    static void Main()
    {
        Console.Write("введите трёхзначное число: ");
        int chislo = Convert.ToInt32(Console.ReadLine());

        int sotni = chislo / 100;
        int desyatki = (chislo / 10) % 10;
        int edinicy = chislo % 10;

        int summa = sotni + desyatki + edinicy;
        bool isEven = summa % 2 == 0;

        Console.WriteLine("сумма цифр является четным числом: " + isEven);
    }
}