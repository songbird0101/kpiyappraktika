using System;

class TemperatureOutOfRangeException : Exception
{
    public TemperatureOutOfRangeException() : base() { }

    public TemperatureOutOfRangeException(string message) : base(message) { }

    public TemperatureOutOfRangeException(string message, Exception innerException) : base(message, innerException) { }
}

class TemperatureSensor
{
    public void SetTemperature(int temp)
    {
        if (temp < -50 || temp > 50)
        {
            throw new TemperatureOutOfRangeException($"Температура {temp} выходит за пределы допустимого диапазона [-50, 50]");
        }
        Console.WriteLine($"Температура установлена: {temp}°C");
    }
}

class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();

        Console.Write("Введите температуру: ");
        int temp = Convert.ToInt32(Console.ReadLine());

        try
        {
            sensor.SetTemperature(temp);
        }
        catch (TemperatureOutOfRangeException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}