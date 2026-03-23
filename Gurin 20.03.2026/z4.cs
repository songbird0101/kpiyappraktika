using System;

interface IPowerOn
{
    void TogglePower();
}

interface IPowerOff
{
    void TogglePower();
}

class Device : IPowerOn, IPowerOff
{
    void IPowerOn.TogglePower()
    {
        Console.WriteLine("Включение устройства");
    }

    void IPowerOff.TogglePower()
    {
        Console.WriteLine("Выключение устройства");
    }
}

class Program
{
    static void Main()
    {
        Device device = new Device();

        IPowerOn on = device;
        on.TogglePower();

        IPowerOff off = device;
        off.TogglePower();
    }
}