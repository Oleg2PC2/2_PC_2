using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размерность матрицы (через пробел):");
        string[] dimensions = Console.ReadLine().Split(' ');

        int rows, cols;

        // Проверка корректности ввода размерности
        if (dimensions.Length != 2 || !int.TryParse(dimensions[0], out rows) || !int.TryParse(dimensions[1], out cols))
        {
            Console.WriteLine("Ошибка ввода. Введите два целых числа через пробел.");
            return;
        }

        Console.WriteLine($"Введите элементы матрицы {rows}x{cols} (через пробел):");

        // Создание и заполнение матрицы
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] rowElements = Console.ReadLine().Split(' ');
            if (rowElements.Length != cols)
            {
                Console.WriteLine("Ошибка ввода. Введите корректное количество элементов для каждой строки.");
                return;
            }

            for (int j = 0; j < cols; j++)
            {
                if (!int.TryParse(rowElements[j], out matrix[i, j]))
                {
                    Console.WriteLine("Ошибка ввода. Введите целые числа для элементов матрицы.");
                    return;
                }
            }
        }

        // Вывод матрицы
        Console.WriteLine("\nВведенная матрица:");
        PrintMatrix(matrix);

        // Нахождение и вывод суммы элементов каждой строки
        Console.WriteLine("\nСуммы элементов каждой строки:");
        for (int i = 0; i < rows; i++)
        {
            int sum = 0;
            for (int j = 0; j < cols; j++)
            {
                sum += matrix[i, j];
            }
            Console.WriteLine($"Строка {i + 1}: {sum}");
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
