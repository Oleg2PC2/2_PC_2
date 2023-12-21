using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");

        string inputString = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputString))
        {
            Console.WriteLine("Ошибка ввода. Строка не должна быть пустой.");
            return;
        }

        string sortedWords = SortWords(inputString);

        string resultString = RemoveDuplicateLengths(sortedWords);

        Console.WriteLine("\nРезультат:");
        Console.WriteLine(resultString);
    }

    static string SortWords(string inputString)
    {
        string[] words = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var sortedWords = words.OrderBy(word => word.Length);

        string result = string.Join(' ', sortedWords);

        Console.WriteLine("\nОтсортированные слова по длине:");
        Console.WriteLine(result);

        return result;
    }

    static string RemoveDuplicateLengths(string sortedWords)
    {
        string[] words = sortedWords.Split(' ');

        var lengths = new HashSet<int>();

        string result = "";

        foreach (var word in words)
        {
            if (!lengths.Contains(word.Length))
            {
                result += word + " ";

                lengths.Add(word.Length);
            }
        }

        return result.Trim();
    }
}
