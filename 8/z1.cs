using System;
using System.Collections;

class ElevatorRequest
{
    public int FloorNumber { get; set; }
    public string Direction { get; set; }

    public ElevatorRequest(int floor, string direction)
    {
        FloorNumber = floor;
        Direction = direction;
    }

    public void Display()
    {
        Console.WriteLine($"Этаж: {FloorNumber}, Направление: {Direction}");
    }
}

class ElevatorSystem
{
    private Queue requestQueue;

    public ElevatorSystem()
    {
        requestQueue = new Queue();
    }

    public void AddRequest(ElevatorRequest request)
    {
        requestQueue.Enqueue(request);
        Console.WriteLine($"Добавлен вызов на {request.FloorNumber} этаж ({request.Direction})");
    }

    public void ProcessRequests()
    {
        Console.WriteLine("\nОбработка вызовов лифта:");
        while (requestQueue.Count > 0)
        {
            ElevatorRequest request = (ElevatorRequest)requestQueue.Dequeue();
            Console.Write("Лифт едет на ");
            request.Display();
        }
    }

    public int GetPendingRequestsCount()
    {
        return requestQueue.Count;
    }
}

class Program
{
    static void Main()
    {
        ElevatorSystem elevator = new ElevatorSystem();

        elevator.AddRequest(new ElevatorRequest(3, "вверх"));
        elevator.AddRequest(new ElevatorRequest(1, "вниз"));
        elevator.AddRequest(new ElevatorRequest(5, "вверх"));
        elevator.AddRequest(new ElevatorRequest(2, "вниз"));

        Console.WriteLine($"\nОжидает обработки: {elevator.GetPendingRequestsCount()} вызовов");

        elevator.ProcessRequests();

        Console.WriteLine($"\nОсталось вызовов: {elevator.GetPendingRequestsCount()}");
    }
}