using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Phone { get; set; }
}

class Program
{
    static List<Employee> employees = new List<Employee>
    {
        new Employee { FullName = "Иванов Иван Иванович", Position = "Менеджер", Department = "Отдел продаж", Phone = "+7 999 123-45-67" },
        new Employee { FullName = "Петров Петр Петрович", Position = "Разработчик", Department = "IT отдел", Phone = "+7 999 234-56-78" },
        new Employee { FullName = "Сидорова Анна Сергеевна", Position = "Дизайнер", Department = "Дизайн отдел", Phone = "+7 999 345-67-89" }
    };

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Учет сотрудников ===");
            Console.WriteLine("1. Показать всех сотрудников");
            Console.WriteLine("2. Показать сотрудников по должности");
            Console.WriteLine("3. Добавить сотрудника");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите пункт: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllEmployees();
                    break;
                case "2":
                    FilterByPosition();
                    break;
                case "3":
                    AddEmployee();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    static void ShowAllEmployees()
    {
        Console.WriteLine("\nСписок всех сотрудников:");
        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.FullName} | {emp.Position} | {emp.Department} | {emp.Phone}");
        }
    }

    static void FilterByPosition()
    {
        Console.Write("Введите должность (Менеджер/Разработчик/Дизайнер): ");
        string position = Console.ReadLine();

        var filtered = employees.Where(e => e.Position == position).ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine("Сотрудники не найдены");
        }
        else
        {
            foreach (var emp in filtered)
            {
                Console.WriteLine($"{emp.FullName} | {emp.Position} | {emp.Department} | {emp.Phone}");
            }
        }
    }

    static void AddEmployee()
    {
        Console.Write("Введите ФИО: ");
        string name = Console.ReadLine();
        Console.Write("Введите должность: ");
        string position = Console.ReadLine();
        Console.Write("Введите отдел: ");
        string department = Console.ReadLine();
        Console.Write("Введите телефон: ");
        string phone = Console.ReadLine();

        employees.Add(new Employee
        {
            FullName = name,
            Position = position,
            Department = department,
            Phone = phone
        });
        Console.WriteLine("Сотрудник добавлен");
    }
}