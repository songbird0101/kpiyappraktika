

class Program
{
    static void Main()
    {
        Console.Write("Введите A: ");
        int A = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите B: ");
        int B = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Кубы чисел в обратном порядке:");

        Console.WriteLine("while:");
        int i = B;
        while (i >= A)
        {
            int cube = i * i * i;
            Console.WriteLine(cube);
            i--;
        }

        Console.WriteLine("do while:");
        i = B;
        do
        {
            int cube = i * i * i;
            Console.WriteLine(cube);
            i--;
        } while (i >= A);

        Console.WriteLine("for:");
        for (int j = B; j >= A; j--)
        {
            int cube = j * j * j;
            Console.WriteLine(cube);
        }
    }
}