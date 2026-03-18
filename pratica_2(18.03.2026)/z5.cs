

class Program
{
    static void MirrorJaggedArray(int[][] jaggedArray)
    {
        if (jaggedArray == null) return;

        Array.Reverse(jaggedArray);

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if (jaggedArray[i] != null)
                Array.Reverse(jaggedArray[i]);
        }
    }

    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        int[][] jagged = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            Console.Write("Введите количество элементов в строке " + i + ": ");
            int cols = Convert.ToInt32(Console.ReadLine());
            jagged[i] = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                Console.Write("jagged[" + i + "][" + j + "] = ");
                jagged[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < jagged.Length; i++)
        {
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j] + " ");
            }
            Console.WriteLine();
        }

        MirrorJaggedArray(jagged);

        Console.WriteLine("Отражённый массив:");
        for (int i = 0; i < jagged.Length; i++)
        {
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}