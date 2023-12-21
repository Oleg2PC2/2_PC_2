using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива: ");
        int size = int.Parse(Console.ReadLine());

        int[] array = new int[size];

        Console.WriteLine("Введите элементы массива через пробел:");
        string[] inputArray = Console.ReadLine().Split(' ');

        for (int i = 0; i < size; i++)
        {
            array[i] = int.Parse(inputArray[i]);
        }

        PrintUniqueElements(array);
    }

    static void PrintUniqueElements(int[] array)
    {
        Console.WriteLine("\nУникальные элементы массива:");

        var uniqueElements = array.GroupBy(x => x)
                                  .Where(group => group.Count() == 1)
                                  .Select(group => group.Key);

        foreach (var element in uniqueElements)
        {
            Console.Write(element + " ");
        }
    }
}
