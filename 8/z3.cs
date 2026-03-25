using System;
using System.Collections.Generic;

interface ISearchable<T>
{
    T Find(IEnumerable<T> items, Func<T, bool> predicate);
}

class SimpleSearch<T> : ISearchable<T>
{
    public T Find(IEnumerable<T> items, Func<T, bool> predicate)
    {
        foreach (T item in items)
        {
            if (predicate(item))
                return item;
        }
        return default(T);
    }
}

class SearchManager<T>
{
    private ISearchable<T> searchService;

    public SearchManager(ISearchable<T> searchService)
    {
        this.searchService = searchService;
    }

    public T PerformSearch(IEnumerable<T> items, Func<T, bool> predicate)
    {
        return searchService.Find(items, predicate);
    }

    public void DisplaySearchResult(T item)
    {
        if (item == null || item.Equals(default(T)))
        {
            Console.WriteLine("Элемент не найден");
        }
        else
        {
            Console.WriteLine("Найденный элемент: " + item);
        }
    }
}

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        ISearchable<int> searchService = new SimpleSearch<int>();
        SearchManager<int> manager = new SearchManager<int>(searchService);

        int result = manager.PerformSearch(numbers, x => x > 5 && x % 2 == 0);
        manager.DisplaySearchResult(result);

        List<string> names = new List<string> { "Иван", "Петр", "Сергей", "Анна" };
        SearchManager<string> stringManager = new SearchManager<string>(new SimpleSearch<string>());
        string nameResult = stringManager.PerformSearch(names, n => n == "Сергей");
        stringManager.DisplaySearchResult(nameResult);
    }
}