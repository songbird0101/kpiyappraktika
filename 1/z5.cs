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

        bool ravny = (sotni == desyatki) && (desyatki == edinicy);

        Console.WriteLine("цифры одинаковы: " + ravny);
    }
}