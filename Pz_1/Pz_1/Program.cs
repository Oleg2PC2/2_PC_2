using System;

class LinearTaskSolver
{
    static void Main()
    {
        // Приглашение ввести значения переменных
        Console.WriteLine("Введите значения переменных:");

        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());

        Console.Write("tga: ");
        double tga = double.Parse(Console.ReadLine());

        // Решение линейной задачи
        double result = SolveLinearTask(a, b, c, tga);

        // Вывод результата
        Console.WriteLine("Результат: " + result);
    }

    static double SolveLinearTask(double a, double b, double c, double tga)
    {
        // Разбиваем выражение на части для удобства вычислений
        double part1 = Math.Pow(a, 2) - Math.Pow(b, 2);
        double part2 = Math.Sin(b);
        double part3 = Math.Pow(10, 4) * Math.Sqrt(Math.Pow(Math.Sin(a + b) - b * c, 2));
        double part4 = Math.Pow(part3, 5);
        double part5 = 4 + tga / Math.Pow(Math.E, 3);

        // Вычисляем значение выражения
        double result = Math.Abs(part1) / (part2 - part4 - part5);

        return result;
    }
}
