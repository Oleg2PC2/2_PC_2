using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст счетов за коммунальные услуги:");
        string inputText = Console.ReadLine();

        // Проверка на пустой ввод
        if (string.IsNullOrWhiteSpace(inputText))
        {
            Console.WriteLine("Ошибка ввода. Текст не должен быть пустым.");
            return;
        }

        // Задание 1: Извлечение всех чисел из текста
        int[] numbers = ExtractNumbers(inputText);

        // Задание 2: Вычисление итоговой суммы
        int totalSum = CalculateTotalSum(numbers);

        // Вывод результата
        Console.WriteLine($"\nИтоговая сумма для оплаты коммунальных услуг: {totalSum}");
    }

    // Метод для извлечения всех чисел из текста
    static int[] ExtractNumbers(string inputText)
    {
        // Разделение текста на слова
        string[] words = inputText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Массив для хранения чисел
        int[] numbers = new int[words.Length];

        int count = 0;

        foreach (var word in words)
        {
            // Попытка преобразования слова в число
            if (int.TryParse(word, out int number))
            {
                numbers[count++] = number;
            }
        }

        // Обрезаем массив до реального размера
        Array.Resize(ref numbers, count);

        return numbers;
    }

    // Метод для вычисления итоговой суммы
    static int CalculateTotalSum(int[] numbers)
    {
        int totalSum = 0;

        foreach (var number in numbers)
        {
            totalSum += number;
        }

        return totalSum;
    }
}
