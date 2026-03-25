using System;

delegate int[] ArrayProcessor(int[] arr);

class Program
{
    static int[] SortAscending(int[] arr)
    {
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted);
        return sorted;
    }

    static int[] SortDescending(int[] arr)
    {
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted);
        Array.Reverse(sorted);
        return sorted;
    }

    static int[] ProcessArray(int[] arr, ArrayProcessor processor)
    {
        return processor(arr);
    }

    static void Main()
    {
        int[] original = { 5, 2, 8, 1, 9, 3 };

        Console.WriteLine("Исходный массив: " + string.Join(", ", original));

        int[] ascending = ProcessArray(original, SortAscending);
        Console.WriteLine("По возрастанию: " + string.Join(", ", ascending));

        int[] descending = ProcessArray(original, SortDescending);
        Console.WriteLine("По убыванию: " + string.Join(", ", descending));
        Console.ReadKey();
    }
}