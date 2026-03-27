using System;

interface IAuthStrategy
{
    bool Authenticate(string username, string password);
}

class OAuthAuth : IAuthStrategy
{
    public bool Authenticate(string username, string password)
    {
        Console.WriteLine("Аутентификация через OAuth");
        return username == "user" && password == "pass";
    }
}

class JWTAuth : IAuthStrategy
{
    public bool Authenticate(string username, string password)
    {
        Console.WriteLine("Аутентификация через JWT");
        return username == "user" && password == "pass";
    }
}

class BasicAuth : IAuthStrategy
{
    public bool Authenticate(string username, string password)
    {
        Console.WriteLine("Базовая аутентификация");
        return username == "user" && password == "pass";
    }
}

class AuthenticationService
{
    private IAuthStrategy strategy;

    public void SetStrategy(IAuthStrategy strategy)
    {
        this.strategy = strategy;
    }

    public bool Login(string username, string password)
    {
        if (strategy == null)
        {
            Console.WriteLine("Стратегия не установлена");
            return false;
        }
        return strategy.Authenticate(username, password);
    }
}

class Program
{
    static void Main()
    {
        AuthenticationService auth = new AuthenticationService();

        auth.SetStrategy(new OAuthAuth());
        Console.WriteLine("Результат: " + auth.Login("user", "pass"));
        Console.WriteLine();

        auth.SetStrategy(new JWTAuth());
        Console.WriteLine("Результат: " + auth.Login("user", "wrong"));
        Console.WriteLine();

        auth.SetStrategy(new BasicAuth());
        Console.WriteLine("Результат: " + auth.Login("user", "pass"));
    }
}