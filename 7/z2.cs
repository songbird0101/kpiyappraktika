using System;
using System.IO;

class ConfigurationException : Exception
{
    public ConfigurationException() : base() { }

    public ConfigurationException(string message) : base(message) { }

    public ConfigurationException(string message, Exception innerException) : base(message, innerException) { }
}

class ConfigLoader
{
    public void LoadConfig(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Файл {path} не найден");
        }
        Console.WriteLine("Конфигурация загружена");
    }
}

class ConfigurationManager
{
    public void LoadConfiguration(string path)
    {
        try
        {
            ConfigLoader loader = new ConfigLoader();
            loader.LoadConfig(path);
        }
        catch (FileNotFoundException ex)
        {
            throw new ConfigurationException("Ошибка загрузки конфигурации", ex);
        }
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager manager = new ConfigurationManager();

        Console.Write("Введите путь к файлу конфигурации: ");
        string path = Console.ReadLine();

        try
        {
            manager.LoadConfiguration(path);
        }
        catch (ConfigurationException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Внутреннее исключение: " + ex.InnerException.Message);
                Console.WriteLine("Стек вызовов: " + ex.StackTrace);
            }
        }
    }
}