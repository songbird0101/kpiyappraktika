using System;

class MyFixedQueue<T>
{
    private T[] items;
    private int head;
    private int tail;
    private int count;

    public MyFixedQueue(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Размер очереди должен быть больше 0");

        items = new T[capacity];
        head = 0;
        tail = 0;
        count = 0;
    }

    public void Enqueue(T item)
    {
        if (count == items.Length)
        {
            Dequeue();
        }

        items[tail] = item;
        tail = (tail + 1) % items.Length;
        count++;
    }

    public T Dequeue()
    {
        if (count == 0)
            throw new InvalidOperationException("Очередь пуста");

        T item = items[head];
        items[head] = default(T);
        head = (head + 1) % items.Length;
        count--;
        return item;
    }

    public T Peek()
    {
        if (count == 0)
            throw new InvalidOperationException("Очередь пуста");

        return items[head];
    }

    public int Count
    {
        get { return count; }
    }

    public int Capacity
    {
        get { return items.Length; }
    }

    public void Display()
    {
        Console.Write("Очередь: ");
        if (count == 0)
        {
            Console.WriteLine("пуста");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            int index = (head + i) % items.Length;
            Console.Write(items[index] + " ");
        }
        Console.WriteLine();
    }
}

class FixedQueueProcessor<T>
{
    private MyFixedQueue<T> queue;

    public FixedQueueProcessor(int capacity)
    {
        queue = new MyFixedQueue<T>(capacity);
    }

    public void AddItem(T item)
    {
        Console.WriteLine($"Добавление: {item}");
        queue.Enqueue(item);
        queue.Display();
        Console.WriteLine($"Текущий размер: {queue.Count}/{queue.Capacity}");
    }

    public T RemoveItem()
    {
        T item = queue.Dequeue();
        Console.WriteLine($"Удаление: {item}");
        queue.Display();
        Console.WriteLine($"Текущий размер: {queue.Count}/{queue.Capacity}");
        return item;
    }

    public T PeekItem()
    {
        T item = queue.Peek();
        Console.WriteLine($"Первый элемент: {item}");
        return item;
    }
}

class Program
{
    static void Main()
    {
        FixedQueueProcessor<int> processor = new FixedQueueProcessor<int>(3);

        processor.AddItem(10);
        processor.AddItem(20);
        processor.AddItem(30);
        processor.AddItem(40);
        processor.AddItem(50);

        processor.PeekItem();
        processor.RemoveItem();
        processor.RemoveItem();

        processor.AddItem(60);
        processor.AddItem(70);
    }
}