
class Program
{
    static void Main()
    {
        Console.Write("Введите порядковый номер дня недели (1-7): ");
        int day = Convert.ToInt32(Console.ReadLine());

        string name;
        switch (day)
        {
            case 1:
                name = "понедельник";
                break;
            case 2:
                name = "вторник";
                break;
            case 3:
                name = "среда";
                break;
            case 4:
                name = "четверг";
                break;
            case 5:
                name = "пятница";
                break;
            case 6:
                name = "суббота";
                break;
            case 7:
                name = "воскресенье";
                break;
            default:
                name = "некорректный номер";
                break;
        }

        Console.WriteLine("Это " + name);
        Console.ReadKey();
       
    }
}