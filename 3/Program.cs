using System;

class Program
{
    static void Main()
    {
        Book[] books = new Book[]
        {
            new Book("Война и мир", "Толстой", 1200, "Роман"),
            new Book("Преступление и наказание", "Достоевский", 400, "Роман"),
            new Book("Краткая история времени", "Хокинг", 250, "Наука"),
            new Book("Мыслящий тростник", "Паскаль", 150, "Философия")
        };

        Library lib = new Library(books);

        Console.WriteLine("Все книги:");
        foreach (Book b in lib.Books)
            b.PrintInfo();

        Book longest = lib.GetLongestBook();
        if (longest != null)
            Console.WriteLine("\nСамая длинная книга: " + longest.Title + " (" + longest.Pages + " стр.)");

        Console.WriteLine("\nКниги жанра 'Роман':");
        Book[] romans = lib.GetBooksByGenre("Роман");
        foreach (Book b in romans)
            Console.WriteLine("  " + b.Title);
    }
}