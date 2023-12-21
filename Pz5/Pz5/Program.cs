using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Таблица значений функции y = |x|:");

        double x = -4.0;

        double h = 0.5;

        while (x <= 4.0)
        {
            double y = Math.Abs(x);

            Console.WriteLine($"x = {x}, y = {y}");

            x += h;
        }
    }
}
