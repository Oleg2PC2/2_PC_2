using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 1: Вычисление n-го члена арифметической прогрессии");
        Console.WriteLine("Введите номер элемента n:");
        int n1 = ReadPositiveInteger();

        double a1 = -100; // первый элемент
        double d1 = 0.5;  // шаг

        double result1 = ArithmeticProgressionNthElement(n1, a1, d1);
        Console.WriteLine($"n-й член арифметической прогрессии: {result1}\n");

        Console.WriteLine("Задание 2: Вычисление n-го члена геометрической прогрессии");
        Console.WriteLine("Введите номер элемента n:");
        int n2 = ReadPositiveInteger();

        double b1 = 9;  // первый элемент
        double q = -3;  // знаменатель прогрессии

        double result2 = GeometricProgressionNthElement(n2, b1, q);
        Console.WriteLine($"n-й член геометрической прогрессии: {result2}\n");

        Console.WriteLine("Задание 3: Вывод чисел от A до B в порядке возрастания или убывания");
        Console.WriteLine("Введите число A:");
        int A = ReadInteger();

        Console.WriteLine("Введите число B:");
        int B = ReadInteger();

        Console.WriteLine("\nЧисла от A до B:");
        if (A < B)
            PrintNumbersAscending(A, B);
        else
            PrintNumbersDescending(A, B);
    }

    // Метод для вычисления n-го члена арифметической прогрессии с использованием рекурсии
    static double ArithmeticProgressionNthElement(int n, double a, double d)
    {
        if (n == 1)
            return a;
        else
            return ArithmeticProgressionNthElement(n - 1, a, d) + d;
    }

    // Метод для вычисления n-го члена геометрической прогрессии с использованием рекурсии
    static double GeometricProgressionNthElement(int n, double b, double q)
    {
        if (n == 1)
            return b;
        else
            return GeometricProgressionNthElement(n - 1, b, q) * q;
    }

    // Метод для вывода чисел от A до B в порядке возрастания с использованием рекурсии
    static void PrintNumbersAscending(int A, int B)
    {
        if (A <= B)
        {
            Console.Write($"{A} ");
            PrintNumbersAscending(A + 1, B);
        }
    }

    // Метод для вывода чисел от A до B в порядке убывания с использованием рекурсии
    static void PrintNumbersDescending(int A, int B)
    {
        if (A >= B)
        {
            Console.Write($"{A} ");
            PrintNumbersDescending(A - 1, B);
        }
    }

    // Метод для ввода положительного целого числа с клавиатуры
    static int ReadPositiveInteger()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.WriteLine("Ошибка ввода. Введите положительное целое число.");
        }
        return number;
    }

    // Метод для ввода целого числа с клавиатуры
    static int ReadInteger()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Ошибка ввода. Введите целое число.");
        }
        return number;
    }
}
