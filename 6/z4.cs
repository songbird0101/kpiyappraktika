using System;

class WeatherEventArgs : EventArgs
{
    public double Temperature { get; set; }
    public double WindSpeed { get; set; }

    public WeatherEventArgs(double temp, double wind)
    {
        Temperature = temp;
        WindSpeed = wind;
    }
}

class WeatherStation
{
    public event EventHandler<WeatherEventArgs> WeatherChanged;

    public void UpdateWeather(double temp, double wind)
    {
        Console.WriteLine($"Метеостанция: новая температура {temp}°C, скорость ветра {wind} м/с");
        WeatherChanged?.Invoke(this, new WeatherEventArgs(temp, wind));
    }
}

class DisplayPanel
{
    public void OnWeatherChanged(object sender, WeatherEventArgs e)
    {
        Console.WriteLine($"DisplayPanel: температура = {e.Temperature}°C, ветер = {e.WindSpeed} м/с");
    }
}

class WarningSystem
{
    public void OnWeatherChanged(object sender, WeatherEventArgs e)
    {
        if (e.WindSpeed > 15)
            Console.WriteLine("WarningSystem: Штормовое предупреждение! Сильный ветер.");
        else
            Console.WriteLine("WarningSystem: Погода в норме.");
    }
}

class WeatherMonitor
{
    public WeatherMonitor(WeatherStation station, DisplayPanel display, WarningSystem warning)
    {
        station.WeatherChanged += display.OnWeatherChanged;
        station.WeatherChanged += warning.OnWeatherChanged;
    }
}

class Program
{
    static void Main()
    {
        WeatherStation station = new WeatherStation();
        DisplayPanel display = new DisplayPanel();
        WarningSystem warning = new WarningSystem();

        WeatherMonitor monitor = new WeatherMonitor(station, display, warning);

        station.UpdateWeather(22.5, 5);
        station.UpdateWeather(18.0, 20);
    }
}