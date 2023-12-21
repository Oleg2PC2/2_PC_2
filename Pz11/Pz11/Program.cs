using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите четыре положительных числа A, B, C, D:");

        // Ввод чисел с клавиатуры
        double A = ReadPositiveNumber("A");
        double B = ReadPositiveNumber("B");
        double C = ReadPositiveNumber("C");
        double D = ReadPositiveNumber("D");

        // Вычисление среднего арифметического и среднего геометрического для пар (A, B), (A, C), (A, D)
        CalculateAndPrintMeans(A, B);
        CalculateAndPrintMeans(A, C);
        CalculateAndPrintMeans(A, D);
    }

    // Процедура для вычисления среднего арифметического и среднего геометрического
    static void Mean(double X, double Y, out double AMean, out double GMean)
    {
        AMean = (X + Y) / 2;
        GMean = Math.Sqrt(X * Y);
    }

    // Метод для ввода положительного числа с клавиатуры
    static double ReadPositiveNumber(string prompt)
    {
        double number;

        do
        {
            Console.Write($"Введите положительное число {prompt}: ");
        } while (!double.TryParse(Console.ReadLine(), out number) || number <= 0);

        return number;
    }

    // Метод для вычисления и вывода среднего арифметического и среднего геометрического
    static void CalculateAndPrintMeans(double A, double B)
    {
        double AMean, GMean;
        Mean(A, B, out AMean, out GMean);

        Console.WriteLine($"\nСреднее арифметическое для ({A}, {B}): {AMean}");
        Console.WriteLine($"Среднее геометрическое для ({A}, {B}): {GMean}");
    }
}
