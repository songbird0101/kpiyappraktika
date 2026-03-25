using System;

class AdminDeletionException : Exception
{
    public AdminDeletionException() : base() { }

    public AdminDeletionException(string message) : base(message) { }

    public AdminDeletionException(string message, Exception innerException) : base(message, innerException) { }
}

class UserManager
{
    public void DeleteUser(string role)
    {
        if (role == "Admin")
        {
            throw new AdminDeletionException("Невозможно удалить пользователя с ролью Admin");
        }
        Console.WriteLine("Пользователь удален");
    }
}

class Program
{
    static void Main()
    {
        UserManager userManager = new UserManager();

        Console.Write("Введите роль пользователя: ");
        string role = Console.ReadLine();

        try
        {
            userManager.DeleteUser(role);
        }
        catch (AdminDeletionException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}