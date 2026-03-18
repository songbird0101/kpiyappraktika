using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] arr = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("arr[" + i + "," + j + "] = ");
                arr[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.Write("Введите номер столбца (от 1 до " + cols + "): ");
        int colNumber = Convert.ToInt32(Console.ReadLine()) - 1;

        if (colNumber < 0 || colNumber >= cols)
        {
            Console.WriteLine("Некорректный номер столбца");
            return;
        }

        Console.Write("Введите заданное число: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        if (divisor == 0)
        {
            Console.WriteLine("Деление на ноль недопустимо");
            return;
        }

        int sum = 0;
        for (int i = 0; i < rows; i++)
        {
            sum += arr[i, colNumber];
        }

        bool isMultiple = (sum % divisor == 0);
        Console.WriteLine("Сумма элементов столбца " + (colNumber + 1) + " равна " + sum);
        Console.WriteLine("Кратна ли сумма заданному числу? " + isMultiple);
        Console.ReadKey();
    }
}