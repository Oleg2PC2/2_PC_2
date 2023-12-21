using System;

class Program
{
    static void Main()
    {
        // Задание 1: 
        Console.WriteLine("Задание 1:");
        for (int i = 20; i <= 100; i += 4)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        // Задание 2: 
        Console.WriteLine("Задание 2:");
        char startChar = 'Е';
        int n = 6;
        for (int i = 0; i < n; i++)
        {
            Console.Write((char)(startChar + i) + " ");
        }
        Console.WriteLine("\n");

        // Задание 3: 
        Console.WriteLine("Задание 3:");
        int m = 9;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Задание 4: 
        Console.WriteLine("Задание 4:");
        int divisor = 5;
        int count = 0;
        for (int i = 90; i <= 900; i++)
        {
            if (i % divisor == 0)
            {
                Console.Write(i + " ");
                count++;
            }
        }
        Console.WriteLine("\nКоличество кратных чисел: " + count + "\n");

        // Задание 5: 
        Console.WriteLine("Задание 5:");
        int startValueI = 5;
        int startValueJ = 99;
        int requiredDifference = 4;

        while (Math.Abs(startValueI - startValueJ) > requiredDifference)
        {
            Console.WriteLine($"i = {startValueI}, j = {startValueJ}");
            startValueI++;
            startValueJ--;
        }
        Console.WriteLine($"i = {startValueI}, j = {startValueJ}\n");
    }
}