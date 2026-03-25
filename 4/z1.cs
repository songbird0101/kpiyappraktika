using System;

static class ArrayHelper
{
    public static double Average(double[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Массив не может быть пустым или null");

        double sum = 0;   
        foreach (double value in array)
        {
            sum += value;
        }
        return sum / array.Length;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов массива: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] numbers = new double[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Введите элемент " + (i + 1) + ": ");
            numbers[i] = Convert.ToDouble(Console.ReadLine());
        }

        double avg = ArrayHelper.Average(numbers);
        Console.WriteLine("Среднее значение: " + avg);
        Console.ReadKey();
    }
}