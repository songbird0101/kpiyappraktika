using System;

delegate void UserLoggedInHandler(string username);

class UserLoginManager
{
    public event UserLoggedInHandler UserLoggedIn;

    public void Login(string username)
    {
        Console.WriteLine("Пользователь " + username + " пытается войти...");
        UserLoggedIn?.Invoke(username);
    }
}


class SecuritySystem
{
    public void OnUserLoggedIn(string username)
    {
        if (username == "admin")
            Console.WriteLine("SecuritySystem: Доступ разрешён для " + username);
        else
            Console.WriteLine("SecuritySystem: Доступ ограничен для " + username);
    }
}


class NotificationService
{
    public void OnUserLoggedIn(string username)
    {
        Console.WriteLine("NotificationService: Отправлено уведомление о входе пользователя " + username);
    }
}

class Program
{
    static void Main()
    {
     
        UserLoginManager loginManager = new UserLoginManager();

       
        SecuritySystem security = new SecuritySystem();
        NotificationService notification = new NotificationService();

    
        loginManager.UserLoggedIn += security.OnUserLoggedIn;
        loginManager.UserLoggedIn += notification.OnUserLoggedIn;

        loginManager.Login("admin");
        Console.WriteLine();
        loginManager.Login("guest");
        Console.ReadKey();
    }
}