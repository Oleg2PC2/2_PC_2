using System;

class Program
{
    static void Main()
    {
        // Задание 1: Создание ступенчатого массива и его заполнение
        char[][] jaggedArray = GenerateJaggedArray();

        // Задание 2: Вывод сгенерированного массива в консоль
        Console.WriteLine("Задание 2: Исходный ступенчатый массив:");
        PrintJaggedArray(jaggedArray);

        // Задание 3: Создание и вывод нового одномерного массива с последними элементами каждой строки
        char[] lastElementsArray = GetLastElementsArray(jaggedArray);
        Console.WriteLine("\nЗадание 3: Одномерный массив с последними элементами каждой строки:");
        PrintCharArray(lastElementsArray);

        // Задание 4: Поиск максимальных элементов в каждой строке и вывод массива
        char[] maxElementsArray = FindMaxElements(jaggedArray);
        Console.WriteLine("\nЗадание 4: Максимальные элементы в каждой строке:");
        PrintCharArray(maxElementsArray);

        // Задание 5: Замена первого элемента на максимальный в каждой строке и вывод обновленного массива
        ReplaceFirstWithMax(jaggedArray);
        Console.WriteLine("\nЗадание 5: Обновленный ступенчатый массив после замены:");
        PrintJaggedArray(jaggedArray);

        // Задание 6: Реверс каждой строки ступенчатого массива
        ReverseJaggedArrayRows(jaggedArray);
        Console.WriteLine("\nЗадание 6: Ступенчатый массив после реверса строк:");
        PrintJaggedArray(jaggedArray);

        // Задание 7a: Среднее значение в каждой строке для числовых значений
        double[] averageValues = CalculateAverageValues(jaggedArray);
        Console.WriteLine("\nЗадание 7a: Средние значения в каждой строке (для чисел):");
        PrintDoubleArray(averageValues);

        // Задание 7b: Общее количество символов в строках каждой строки массива
        int[] charCountArray = CalculateCharCount(jaggedArray);
        Console.WriteLine("\nЗадание 7b: Общее количество символов в каждой строке:");
        PrintIntArray(charCountArray);

        // Задание 7c: Наиболее встречающиеся символы в каждой строке ступенчатого массива
        char[] mostFrequentChars = FindMostFrequentChars(jaggedArray);
        Console.WriteLine("\nЗадание 7c: Наиболее встречающиеся символы в каждой строке:");
        PrintCharArray(mostFrequentChars);
    }

    // Метод для генерации ступенчатого массива с рандомными длинами строк
    static char[][] GenerateJaggedArray()
    {
        Random random = new Random();
        int rows = 4; // Количество строк
        char[][] jaggedArray = new char[rows][];

        for (int i = 0; i < rows; i++)
        {
            int randomLength = random.Next(10, 16); // Генерация случайной длины строки от 10 до 15 символов
            jaggedArray[i] = new char[randomLength];

            for (int j = 0; j < randomLength; j++)
            {
                // Заполнение массива символами от 'A' до 'Z'
                jaggedArray[i][j] = (char)(random.Next(26) + 'A');
            }
        }

        return jaggedArray;
    }

    // Метод для вывода ступенчатого массива в консоль
    static void PrintJaggedArray(char[][] jaggedArray)
    {
        foreach (char[] row in jaggedArray)
        {
            foreach (char element in row)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }

    // Метод для вывода одномерного массива символов в консоль
    static void PrintCharArray(char[] array)
    {
        foreach (char element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    // Метод для создания и заполнения одномерного массива последними элементами каждой строки ступенчатого массива
    static char[] GetLastElementsArray(char[][] jaggedArray)
    {
        int rows = jaggedArray.Length;
        char[] resultArray = new char[rows];

        for (int i = 0; i < rows; i++)
        {
            resultArray[i] = jaggedArray[i][jaggedArray[i].Length - 1];
        }

        return resultArray;
    }

    // Метод для поиска максимальных элементов в каждой строке ступенчатого массива
    static char[] FindMaxElements(char[][] jaggedArray)
    {
        int rows = jaggedArray.Length;
        char[] maxElementsArray = new char[rows];

        for (int i = 0; i < rows; i++)
        {
            char maxElement = jaggedArray[i][0];
            foreach (char element in jaggedArray[i])
            {
                if (element > maxElement)
                    maxElement = element;
            }
            maxElementsArray[i] = maxElement;
        }

        return maxElementsArray;
    }

    // Метод для замены первого элемента на максимальный в каждой строке ступенчатого массива
    static void ReplaceFirstWithMax(char[][] jaggedArray)
    {
        int rows = jaggedArray.Length;

        for (int i = 0; i < rows; i++)
        {
            char maxElement = jaggedArray[i][0];
            int maxIndex = 0;

            // Поиск максимального элемента
            for (int j = 1; j < jaggedArray[i].Length; j++)
            {
                if (jaggedArray[i][j] > maxElement)
                {
                    maxElement = jaggedArray[i][j];
                    maxIndex = j;
                }
            }

            // Замена первого элемента на максимальный
            char temp = jaggedArray[i][0];
            jaggedArray[i][0] = maxElement;
            jaggedArray[i][maxIndex] = temp;
        }
    }

    // Метод для реверса каждой строки ступенчатого массива
    static void ReverseJaggedArrayRows(char[][] jaggedArray)
    {
        foreach (char[] row in jaggedArray)
        {
            Array.Reverse(row);
        }
    }

    // Метод для вычисления средних значений в каждой строке (для чисел)
    static double[] CalculateAverageValues(char[][] jaggedArray)
    {
        int rows = jaggedArray.Length;
        double[] averageValues = new double[rows];

        for (int i = 0; i < rows; i++)
        {
            int sum = 0;
            foreach (char element in jaggedArray[i])
            {
                sum += (int)element;
            }

            averageValues[i] = (double)sum / jaggedArray[i].Length;
        }

        return averageValues;
    }

    // Метод для подсчета общего количества символов в каждой строке массива
    static int[] CalculateCharCount(char[][] jaggedArray)
    {
        int rows = jaggedArray.Length;
        int[] charCountArray = new int[rows];

        for (int i = 0; i < rows; i++)
        {
            charCountArray[i] = jaggedArray[i].Length;
        }

        return charCountArray;
    }

    // Метод для поиска наиболее встречающихся символов в каждой строке ступенчатого массива
    static char[] FindMostFrequentChars(char[][] jaggedArray)
    {
        int rows = jaggedArray.Length;
        char[] mostFrequentChars = new char[rows];

        for (int i = 0; i < rows; i++)
        {
            int[] charCount = new int[26]; // Учитываем только большие буквы
            foreach (char element in jaggedArray[i])
            {
                char uppercaseChar = char.ToUpper(element);
                if (uppercaseChar >= 'A' && uppercaseChar <= 'Z')
                {
                    charCount[uppercaseChar - 'A']++;
                }
            }

            int maxCount = 0;
            char mostFrequentChar = 'A';

            for (int j = 0; j < 26; j++)
            {
                if (charCount[j] > maxCount)
                {
                    maxCount = charCount[j];
                    mostFrequentChar = (char)('A' + j);
                }
            }

            mostFrequentChars[i] = mostFrequentChar;
        }

        return mostFrequentChars;
    }

    // Метод для вывода массива чисел с плавающей точкой в консоль
    static void PrintDoubleArray(double[] array)
    {
        foreach (double element in array)
        {
            Console.Write($"{element:F2} ");
        }
        Console.WriteLine();
    }

    // Метод для вывода массива целых чисел в консоль
    static void PrintIntArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }
}
