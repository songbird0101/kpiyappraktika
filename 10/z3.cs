using System;
using System.Collections.Generic;

interface IOrderObserver
{
    void Update(string orderStatus, int orderId);
}

class Customer : IOrderObserver
{
    private string name;

    public Customer(string name)
    {
        this.name = name;
    }

    public void Update(string orderStatus, int orderId)
    {
        Console.WriteLine("Клиент " + name + ": заказ " + orderId + " - " + orderStatus);
    }
}

class Chef : IOrderObserver
{
    public void Update(string orderStatus, int orderId)
    {
        if (orderStatus == "Новый заказ")
        {
            Console.WriteLine("Повар: готовлю заказ " + orderId);
        }
    }
}

class Waiter : IOrderObserver
{
    public void Update(string orderStatus, int orderId)
    {
        if (orderStatus == "Готов")
        {
            Console.WriteLine("Официант: заказ " + orderId + " готов к подаче");
        }
    }
}

class OrderSystem
{
    private List<IOrderObserver> observers = new List<IOrderObserver>();
    private int nextOrderId = 1;

    public void Subscribe(IOrderObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IOrderObserver observer)
    {
        observers.Remove(observer);
    }

    public void CreateOrder()
    {
        int orderId = nextOrderId++;
        Console.WriteLine("\nСоздан новый заказ " + orderId);
        NotifyObservers("Новый заказ", orderId);
    }

    public void UpdateOrderStatus(int orderId, string status)
    {
        Console.WriteLine("\nЗаказ " + orderId + ": статус изменён на '" + status + "'");
        NotifyObservers(status, orderId);
    }

    private void NotifyObservers(string status, int orderId)
    {
        foreach (IOrderObserver observer in observers)
        {
            observer.Update(status, orderId);
        }
    }
}

class Program
{
    static void Main()
    {
        OrderSystem orderSystem = new OrderSystem();

        Customer customer = new Customer("Иван");
        Chef chef = new Chef();
        Waiter waiter = new Waiter();

        orderSystem.Subscribe(customer);
        orderSystem.Subscribe(chef);
        orderSystem.Subscribe(waiter);

        orderSystem.CreateOrder();
        orderSystem.UpdateOrderStatus(1, "Готов");
    }
}