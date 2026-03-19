using System;

partial class Book
{
    public void PrintInfo()
    {
        Console.WriteLine(Title + " (" + Genre + ") - " + Author + ", " + Pages + " стр.");
    }
}