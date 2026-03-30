using System;
using System.Collections.Generic;

class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }

    public Employee(string fullName, string position)
    {
        FullName = fullName;
        Position = position;
    }

    public void Display()
    {
        Console.WriteLine($"{FullName,-30} {Position,-20}");
    }
}

class Program
{
    static List<Employee> employees = new List<Employee>();

    static void Main()
    {
        employees.Add(new Employee("Иванов Иван Иванович", "Менеджер"));
        employees.Add(new Employee("Петров Петр Петрович", "Разработчик"));
        employees.Add(new Employee("Сидорова Анна Сергеевна", "Дизайнер"));
        employees.Add(new Employee("Кузнецов Дмитрий Алексеевич", "Разработчик"));
        employees.Add(new Employee("Смирнова Елена Владимировна", "Менеджер"));

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Учет сотрудников");

            Console.WriteLine();

            Console.WriteLine("Список сотрудников:");
            Console.WriteLine(new string('-', 55));
            Console.WriteLine($"{"ФИО",-30} {"Должность",-20}");
            Console.WriteLine(new string('-', 55));

            foreach (var emp in employees)
            {
                emp.Display();
            }

            Console.WriteLine(new string('-', 55));
            Console.WriteLine();
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Редактировать сотрудника");
            Console.WriteLine("3. Удалить сотрудника");
            Console.WriteLine("4. Выход");
            Console.WriteLine();
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    EditEmployee();
                    break;
                case "3":
                    DeleteEmployee();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddEmployee()
    {
        Console.Write("Введите ФИО: ");
        string fullName = Console.ReadLine();
        Console.Write("Введите должность: ");
        string position = Console.ReadLine();

        employees.Add(new Employee(fullName, position));
        Console.WriteLine("\nСотрудник добавлен. Нажмите любую клавишу...");
        Console.ReadKey();
    }

    static void EditEmployee()
    {
        Console.Write("Введите номер сотрудника для редактирования (1-" + employees.Count + "): ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= employees.Count)
        {
            Employee emp = employees[index - 1];
            Console.WriteLine($"\nРедактирование сотрудника: {emp.FullName} - {emp.Position}");
            Console.Write("Введите новое ФИО (оставьте пустым, чтобы не менять): ");
            string newName = Console.ReadLine();
            Console.Write("Введите новую должность (оставьте пустым, чтобы не менять): ");
            string newPosition = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
                emp.FullName = newName;
            if (!string.IsNullOrWhiteSpace(newPosition))
                emp.Position = newPosition;

            Console.WriteLine("\nСотрудник обновлен. Нажмите любую клавишу...");
        }
        else
        {
            Console.WriteLine("Неверный номер. Нажмите любую клавишу...");
        }
        Console.ReadKey();
    }

    static void DeleteEmployee()
    {
        Console.Write("Введите номер сотрудника для удаления (1-" + employees.Count + "): ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= employees.Count)
        {
            Console.WriteLine($"Удалить сотрудника {employees[index - 1].FullName}? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                employees.RemoveAt(index - 1);
                Console.WriteLine("Сотрудник удален. Нажмите любую клавишу...");
            }
            else
            {
                Console.WriteLine("Удаление отменено. Нажмите любую клавишу...");
            }
        }
        else
        {
            Console.WriteLine("Неверный номер. Нажмите любую клавишу...");
        }
        Console.ReadKey();
    }
}