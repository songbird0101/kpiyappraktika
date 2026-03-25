

static class ArrayHelper
{
    public static double Product(double[] array)
    {
        double result = 1.0;
        foreach (double d in array)
            result *= d;
        return result;
    }

    public static void Sort(double[] array)
    {
        Array.Sort(array);
    }

    public static double[] Filter(double[] array, Predicate<double> condition)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
            if (condition(array[i]))
                count++;
        double[] result = new double[count];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
            if (condition(array[i]))
                result[index++] = array[i];
        return result;
    }

    public static void Statistics(double[] array, out double min, out double max, out double sum, out double average)
    {
        if (array.Length == 0)
        {
            min = max = sum = average = 0;
            return;
        }
        min = max = array[0];
        sum = 0;
        foreach (double d in array)
        {
            if (d < min) min = d;
            if (d > max) max = d;
            sum += d;
        }
        average = sum / array.Length;
    }

    public static double[] Generate(int count, double min, double max)
    {
        Random rnd = new Random();
        double[] array = new double[count];
        for (int i = 0; i < count; i++)
            array[i] = rnd.NextDouble() * (max - min) + min;
        return array;
    }
}

class Program
{
    static void Main()
    {
        double[] arr = ArrayHelper.Generate(5, 1.0, 10.0);
        Console.WriteLine("Сгенерированный массив:");
        foreach (double d in arr)
            Console.Write(d + " ");
        Console.WriteLine();

        Console.WriteLine("Произведение элементов: " + ArrayHelper.Product(arr));

        ArrayHelper.Sort(arr);
        Console.WriteLine("Отсортированный массив:");
        foreach (double d in arr)
            Console.Write(d + " ");
        Console.WriteLine();

        double[] filtered = ArrayHelper.Filter(arr, x => x > 5);
        Console.WriteLine("Элементы > 5:");
        foreach (double d in filtered)
            Console.Write(d + " ");
        Console.WriteLine();

        double min, max, sum, avg;
        ArrayHelper.Statistics(arr, out min, out max, out sum, out avg);
        Console.WriteLine("Статистика: min = " + min + ", max = " + max + ", sum = " + sum + ", avg = " + avg);
    }
}