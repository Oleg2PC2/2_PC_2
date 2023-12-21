using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите значения средних суточных температур за неделю:");

        // Ввод массива температур с клавиатуры
        double[] temperatures = new double[7];
        for (int i = 0; i < temperatures.Length; i++)
        {
            temperatures[i] = ReadTemperature($"День {i + 1}: ");
        }

        // Вызов метода и вывод результата
        int daysBelowZero = CountDaysBelowZero(temperatures);
        Console.WriteLine($"\nКоличество дней, в которых температура опускалась ниже нуля: {daysBelowZero}");
    }

    // Метод для ввода температуры с клавиатуры
    static double ReadTemperature(string prompt)
    {
        double temperature;

        do
        {
            Console.Write($"{prompt}");
        } while (!double.TryParse(Console.ReadLine(), out temperature));

        return temperature;
    }

    // Метод для подсчета количества дней, в которых температура опускалась ниже нуля
    static int CountDaysBelowZero(double[] temperatures)
    {
        int count = 0;

        foreach (var temperature in temperatures)
        {
            if (temperature < 0)
            {
                count++;
            }
        }

        return count;
    }
}
