using System;

abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }

    public Book(string title, string author, int pages)
    {
        Title = title;
        Author = author;
        Pages = pages;
    }
}

sealed class FictionBook : Book
{
    public FictionBook(string title, string author, int pages) : base(title, author, pages) { }
}

sealed class NonFictionBook : Book
{
    public NonFictionBook(string title, string author, int pages) : base(title, author, pages) { }
}

class Library
{
    public Book[] Books { get; set; }

    public Library(Book[] books)
    {
        Books = books;
    }

    public int GetTotalPages()
    {
        int total = 0;
        foreach (Book b in Books)
            total += b.Pages;
        return total;
    }

    public Book[] GetBooksByAuthor(string author)
    {
        int count = 0;
        foreach (Book b in Books)
            if (b.Author == author)
                count++;
        Book[] result = new Book[count];
        int index = 0;
        foreach (Book b in Books)
            if (b.Author == author)
                result[index++] = b;
        return result;
    }

    public void PrintAllBooks()
    {
        foreach (Book b in Books)
            Console.WriteLine("Название: " + b.Title + ", Автор: " + b.Author + ", Страниц: " + b.Pages);
    }
}

class Program
{
    static void Main()
    {
        Book[] books = new Book[]
        {
            new FictionBook("Война и мир", "Толстой", 1200),
            new FictionBook("Преступление и наказание", "Достоевский", 400),
            new NonFictionBook("Краткая история времени", "Хокинг", 250),
            new NonFictionBook("Мыслящий тростник", "Паскаль", 150)
        };

        Library lib = new Library(books);

        Console.WriteLine("Все книги библиотеки:");
        lib.PrintAllBooks();

        Console.WriteLine("Общее количество страниц: " + lib.GetTotalPages());

        Console.WriteLine("Книги автора Толстой:");
        Book[] authorBooks = lib.GetBooksByAuthor("Толстой");
        foreach (Book b in authorBooks)
            Console.WriteLine("  " + b.Title);
    }
}